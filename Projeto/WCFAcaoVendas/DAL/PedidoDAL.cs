using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using WCFAcaoVendas.Services;

namespace WCFAcaoVendas.DAL
{
    public abstract class PedidoDAL
    {
        public static InfoPedido[] BuscarDados(string codigo)
        {
            try
            {
                using (SqlConnection conexao = FabricaSql.NovaConexao())
                {
                    using (SqlCommand comando = FabricaSql.NovoComandoTexto(conexao))
                    {
                        var query = new StringBuilder();
                        query.AppendLine("select    top(50) ip.tipoRegistro, ip.numPedidoAndroid, ip.codigoCliente, ip.controleCgc, ip.cpfCgc, ip.dataPedido, ip.dataEntrega, ip.frete, ip.codigoVendedor, ip.numPedidoCliente, ip.operacao, ip.entregaImediata, ip.prazo, ip.tabelaPreco, ip.percDesconto, ip.observacao, ip.codigoMensagem, ip.codigoFilial, ip.dataEnvio, ip.situacao");
                        query.AppendLine("from      ImportacaoPedido ip ");
                        query.AppendLine("where     ip.codigoVendedor = @codigo");
                        query.AppendLine("order by  ip.dataPedido desc");

                        comando.CommandText = query.ToString();
                        comando.Parameters.Add("@codigo", SqlDbType.VarChar).Value = codigo;

                        DataTable dt = FabricaSql.GeraDataTable(comando);

                        List<InfoPedido> registros = new List<InfoPedido>();
                        foreach (DataRow row in dt.Rows)
                        {
                            InfoPrincipal infoPrincipal = new InfoPrincipal(row.Field<string>("tipoRegistro"), row.Field<string>("numPedidoAndroid"), row.Field<string>("codigoCliente"), row.Field<string>("controleCgc"), row.Field<string>("cpfCgc"), row.Field<string>("dataPedido"), row.Field<string>("dataEntrega"), row.Field<string>("frete"), row.Field<string>("codigoVendedor"), row.Field<string>("numPedidoCliente"), row.Field<string>("operacao"), row.Field<string>("entregaImediata"), row.Field<string>("prazo"), row.Field<string>("tabelaPreco"), row.Field<Single>("percDesconto"), row.Field<string>("observacao"), row.Field<string>("codigoMensagem"), row.Field<string>("codigoFilial"), row.Field<string>("dataEnvio"), row.Field<string>("situacao"));
                            registros.Add(new InfoPedido(infoPrincipal, BuscaCondicaoPagamentoPedido(infoPrincipal.NumPedidoAndroid, comando), BuscaItensPedido(infoPrincipal.NumPedidoAndroid, comando), infoPrincipal.Situacao));
                        }

                        return registros.ToArray();
                    }
                }
            }
            catch (Exception exception)
            {
                LogErro.Registrar(exception.Message);
                throw;
            }
        }

        private static InfoCondicaoPagamento[] BuscaCondicaoPagamentoPedido(string codigoPedido, SqlCommand comando)
        {
            var query = new StringBuilder();
            query.AppendLine("select iv.tipoRegistro, iv.numPedidoAndroid, iv.prazo, iv.dtVencimentoParc, iv.valorParcela, iv.formaPagamento, iv.situacao ");
            query.AppendLine("from ImportacaoVencimentos iv ");
            query.AppendLine("where iv.numPedidoAndroid = @codigoPedido; ");

            comando.CommandText = query.ToString();
            comando.Parameters.Clear();
            comando.Parameters.Add("@codigoPedido", SqlDbType.VarChar).Value = codigoPedido;

            DataTable dt = FabricaSql.GeraDataTable(comando);

            List<InfoCondicaoPagamento> registros = new List<InfoCondicaoPagamento>();
            foreach (DataRow row in dt.Rows)
            {
                registros.Add(new InfoCondicaoPagamento(row.Field<string>("tipoRegistro"), row.Field<string>("numPedidoAndroid"), row.Field<string>("prazo"), row.Field<string>("dtVencimentoParc"), row.Field<Single>("valorParcela"), row.Field<string>("formaPagamento"), row.Field<string>("situacao")));
            }

            return registros.ToArray();
        }

        private static InfoItem[] BuscaItensPedido(string codigoPedido, SqlCommand comando)
        {
            var query = new StringBuilder();
            query.AppendLine("select ii.tipoRegistro, ii.numPedidoAndroid, ii.codigoProduto, ii.quantidade, ii.valorUnitario, ii.percComissao, ii.valorUnitarioTabelaPreco, ii.situacao ");
            query.AppendLine("from ImportacaoItens ii ");
            query.AppendLine("where numPedidoAndroid = @codigoPedido; ");

            comando.CommandText = query.ToString();
            comando.Parameters.Clear();
            comando.Parameters.Add("@codigoPedido", SqlDbType.VarChar).Value = codigoPedido;

            DataTable dt = FabricaSql.GeraDataTable(comando);

            List<InfoItem> registros = new List<InfoItem>();
            foreach (DataRow row in dt.Rows)
            {
                registros.Add(new InfoItem(row.Field<string>("tipoRegistro"), row.Field<string>("numPedidoAndroid"), row.Field<string>("codigoProduto"), row.Field<Single>("quantidade"), row.Field<Single>("valorUnitario"), row.Field<Single>("percComissao"), row.Field<Single>("valorUnitarioTabelaPreco"), row.Field<string>("situacao")));
            }

            return registros.ToArray();
        }

        public static Email[] Atualiza(InfoPedido[] pedidos)
        {
            try
            {
                using (SqlConnection conexao = FabricaSql.NovaConexao())
                {
                    using (SqlCommand comando = FabricaSql.NovoComandoTexto(conexao))
                    {

                        foreach (var pedido in pedidos)
                        {
                            if (pedido.Situacao == "1")    //Novo pedido
                            {
                                InserirDados(comando, pedido);
                            }
                            else if (pedido.Situacao == "2") //Pedido alterado
                            {
                                //VerificaSePedidoAindaNaoImportado();
                                //AlterarDados(comando, cliente);
                            }
                            else
                            {
                                throw new Exception("Campo situação não encontrado.");
                            }

                            return GeraEmail(pedidos);
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                LogErro.Registrar(exception.Message);
                throw;
            }

        }

        private static Email[] GeraEmail(InfoPedido[] pedidos)
        {
            List<Email> list = new List<Email>();
            foreach (var pedido in pedidos)
            {
                var nomeVendedor = BuscaNomeVendedor(pedido.InfoPrincipal.CodigoVendedor);
                InfoCliente cliente = BuscaNomeCliente(pedido.InfoPrincipal.CodigoCliente);
                var nomeCidade = BuscaNomeCidade(cliente.CodigoMunicipio);
                var valorTotalPedido = 0;

                var mensagem = String.Format("<b>Pedido realizado por {0} em {1}.</b>", nomeVendedor, pedido.InfoPrincipal.DtPedido);
                mensagem += "<br /><br /><b>Solicitação de: </b><br />" + cliente.NomeCliente;
                mensagem += "Endereço: <br />" + cliente.Endereco + ", " + cliente.NumeroEndereco + ", " + cliente.Bairro + ", " + nomeCidade;
                mensagem += "<br /><br />Itens do pedidos: ";

                for (int i = 0; i < pedido.InfoItens.Length; i++)
                {
                    var nomeProduto = BuscaNomeProduto(pedido.InfoItens[i].CodigoProduto);
                    var valorTotalProduto = Convert.ToInt32(pedido.InfoItens[i].Quantidade) * Convert.ToInt32(pedido.InfoItens[i].ValorUnitario);

                    mensagem += String.Format("<br />Produto: {0} - {1} ", pedido.InfoItens[i].CodigoProduto, nomeProduto);
                    mensagem += "<br />Quantidade: " + pedido.InfoItens[i].Quantidade;
                    mensagem += "<br />Valor unitário: R$" + pedido.InfoItens[i].ValorUnitario;
                    mensagem += "<br />Total: R$" + valorTotalProduto;
                    mensagem += "<br /><br />;";

                    valorTotalPedido += valorTotalProduto;
                }

                mensagem += "<b>Total pedido:</b> R$" + valorTotalPedido;

                var email = new Email(String.Format("Pedido nº - {0}", pedido.InfoPrincipal.NumPedidoAndroid), mensagem);

                email.Destinatarios.Add(DataBase.BuscaUsuario(model.Cabecalho.IdProprietario).Email); //usuário que está alterando o chamado
                email.Destinatarios.Add(model.Cabecalho.Autor.Email); //usuário que está alterando o chamado

                list.Add(email);
            }

            return list.ToArray();
        }

        private static void InserirDados(SqlCommand comando, InfoPedido infoPedido)
        {
            var query = new StringBuilder();
            query.AppendLine("insert into ImportacaoPedido (ip.tipoRegistro, ip.numPedidoAndroid, ip.codigoCliente, ip.controleCgc, ip.cpfCgc, ip.dataPedido, ip.dataEntrega, ip.frete, ip.codigoVendedor, ");
            query.AppendLine("ip.numPedidoCliente, ip.operacao, ip.entregaImediata, ip.prazo, ip.tabelaPreco, ip.percDesconto, ip.observacao, ip.codigoMensagem, ip.codigoFilial, ip.dataEnvio, ip.situacao)");
            query.AppendLine("values (@tipoRegistro, @numPedidoAndroid, @codigoCliente, @controleCgc, @cpfCgc, @dataPedido, @dataEntrega, @frete, @codigoVendedor, ");
            query.AppendLine("@numPedidoCliente, @operacao, @entregaImediata, @prazo, @tabelaPreco, @percDesconto, @observacao, @codigoMensagem, @codigoFilial, @dataEnvio , @situacao); ");

            comando.Parameters.Add("@tipoRegistro", SqlDbType.VarChar).Value = infoPedido.InfoPrincipal.TipoRegistro;
            comando.Parameters.Add("@numPedidoAndroid", SqlDbType.VarChar).Value = infoPedido.InfoPrincipal.NumPedidoAndroid;
            comando.Parameters.Add("@codigoCliente", SqlDbType.VarChar).Value = infoPedido.InfoPrincipal.CodigoCliente;
            comando.Parameters.Add("@controleCgc", SqlDbType.VarChar).Value = infoPedido.InfoPrincipal.ControleCgc;
            comando.Parameters.Add("@cpfCgc", SqlDbType.VarChar).Value = infoPedido.InfoPrincipal.CpfCgc;
            comando.Parameters.Add("@dataPedido", SqlDbType.VarChar).Value = infoPedido.InfoPrincipal.DtPedido;
            comando.Parameters.Add("@dataEntrega", SqlDbType.VarChar).Value = infoPedido.InfoPrincipal.DtEntrega;
            comando.Parameters.Add("@frete", SqlDbType.VarChar).Value = infoPedido.InfoPrincipal.Frete;
            comando.Parameters.Add("@codigoVendedor", SqlDbType.VarChar).Value = infoPedido.InfoPrincipal.CodigoVendedor;
            comando.Parameters.Add("@numPedidoCliente", SqlDbType.VarChar).Value = infoPedido.InfoPrincipal.NumPedidoCliente;
            comando.Parameters.Add("@operacao", SqlDbType.VarChar).Value = infoPedido.InfoPrincipal.Operacao;
            comando.Parameters.Add("@entregaImediata", SqlDbType.VarChar).Value = infoPedido.InfoPrincipal.EntregaImediata;
            comando.Parameters.Add("@prazo", SqlDbType.VarChar).Value = infoPedido.InfoPrincipal.Prazo;
            comando.Parameters.Add("@tabelaPreco", SqlDbType.VarChar).Value = infoPedido.InfoPrincipal.TabelaPreco;
            comando.Parameters.Add("@percDesconto", SqlDbType.Real).Value = infoPedido.InfoPrincipal.PercDesconto;
            comando.Parameters.Add("@observacao", SqlDbType.VarChar).Value = infoPedido.InfoPrincipal.Observacao;
            comando.Parameters.Add("@codigoMensagem", SqlDbType.VarChar).Value = infoPedido.InfoPrincipal.CodigoMensagem;
            comando.Parameters.Add("@codigoFilial", SqlDbType.VarChar).Value = infoPedido.InfoPrincipal.CodigoFilial;
            comando.Parameters.Add("@dataEnvio", SqlDbType.VarChar).Value = infoPedido.InfoPrincipal.DtEnvio;
            comando.Parameters.Add("@situacao", SqlDbType.VarChar).Value = infoPedido.Situacao;

            comando.Parameters.Clear();

            for (int i = 0; i < infoPedido.InfoItens.Length; i++)
            {
                query.AppendLine("insert into ImportacaoItens (ii.tipoRegistro, ii.numPedidoAndroid, ii.codigoProduto, ii.quantidade, ii.valorUnitario, ii.percComissao, ii.valorUnitarioTabelaPreco, ii.situacao) ");
                query.AppendLine("values (@tipoRegistro, @numPedidoAndroid, @codigoProduto, @quantidade, @valorUnitario, @percComissao, @valorUnitarioTabelaPreco, @situacao); ");

                comando.Parameters.Add("@tipoRegistro", SqlDbType.VarChar).Value = infoPedido.InfoItens[i].TipoRegistro;
                comando.Parameters.Add("@numPedidoAndroid", SqlDbType.VarChar).Value = infoPedido.InfoItens[i].NumPedidoAndroid;
                comando.Parameters.Add("@codigoProduto", SqlDbType.VarChar).Value = infoPedido.InfoItens[i].CodigoProduto;
                comando.Parameters.Add("@quantidade", SqlDbType.Real).Value = infoPedido.InfoItens[i].Quantidade;
                comando.Parameters.Add("@valorUnitario", SqlDbType.Real).Value = infoPedido.InfoItens[i].ValorUnitario;
                comando.Parameters.Add("@percComissao", SqlDbType.Real).Value = infoPedido.InfoItens[i].PercComissao;
                comando.Parameters.Add("@valorUnitarioTabelaPreco", SqlDbType.Real).Value = infoPedido.InfoItens[i].ValorUnitarioTabelaPreco;
                comando.Parameters.Add("@situacao", SqlDbType.VarChar).Value = infoPedido.Situacao;
            }

            comando.Parameters.Clear();

            for (int i = 0; i < infoPedido.InfoCondicoesPagamento.Length; i++)
            {
                query.AppendLine("insert into ImportacaoVencimentos (iv.tipoRegistro, iv.numPedidoAndroid, iv.prazo, iv.dtVencimentoParc, iv.valorParcela, iv.formaPagamento, iv.situacao) ");
                query.AppendLine("values (@tipoRegistro, @numPedidoAndroid, @prazo, @dtVencimentoParc, @valorParcela, @formaPagamento, @situacao); ");

                comando.Parameters.Add("@tipoRegistro", SqlDbType.VarChar).Value = infoPedido.InfoCondicoesPagamento[i].TipoRegistro;
                comando.Parameters.Add("@numPedidoAndroid", SqlDbType.VarChar).Value = infoPedido.InfoCondicoesPagamento[i].NumPedidoAndroid;
                comando.Parameters.Add("@prazo", SqlDbType.VarChar).Value = infoPedido.InfoCondicoesPagamento[i].PrazoDiasParcela;
                comando.Parameters.Add("@dtVencimentoParc", SqlDbType.VarChar).Value = infoPedido.InfoCondicoesPagamento[i].DtVencimentoParcela;
                comando.Parameters.Add("@valorParcela", SqlDbType.Real).Value = infoPedido.InfoCondicoesPagamento[i].ValorParcela;
                comando.Parameters.Add("@formaPagamento", SqlDbType.VarChar).Value = infoPedido.InfoCondicoesPagamento[i].FormaPagamento;
                comando.Parameters.Add("@situacao", SqlDbType.VarChar).Value = infoPedido.Situacao;
            }

            comando.CommandText = query.ToString();
            comando.ExecuteNonQuery();
        }
    }
}