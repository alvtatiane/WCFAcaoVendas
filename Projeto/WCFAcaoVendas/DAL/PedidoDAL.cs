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
                        query.AppendLine("select ip.tipoRegistro, ip.numPedidoAndroid ");
                        query.AppendLine("from ImportacaoPedido ip ");
                        query.AppendLine("where ip.codigoVendedor = @codigo");

                        comando.CommandText = query.ToString();
                        comando.Parameters.Add("@codigo", SqlDbType.VarChar).Value = codigo;

                        DataTable dt = FabricaSql.GeraDataTable(comando);

                        List<InfoPedido> registros = new List<InfoPedido>();
                        foreach (DataRow row in dt.Rows)
                        {
                            InfoPrincipal infoPrincipal = new InfoPrincipal(row.Field<string>(""));
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

        public static void Atualiza(InfoPedido[] pedidos)
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

        private static void InserirDados(SqlCommand comando, InfoPedido infoPedido)
        {
            var query = new StringBuilder();
            query.AppendLine("");

            comando.Parameters.Add("@situacao", SqlDbType.VarChar).Value = infoPedido.Situacao;

            comando.CommandText = query.ToString();
            comando.ExecuteNonQuery();
        }
    }
}