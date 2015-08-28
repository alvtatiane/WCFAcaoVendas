using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using WCFAcaoVendas.Services;
using WCFAcaoVendas.Util;

namespace WCFAcaoVendas.DAL
{
    public abstract class ClienteDAL
    {
        public static InfoCliente[] BuscarDados(string codigo)
        {
            try
            {
                using (SqlConnection conexao = FabricaSql.NovaConexao())
                {
                    using (SqlCommand comando = FabricaSql.NovoComandoTexto(conexao))
                    {
                        var query = new StringBuilder();
                        query.AppendLine("select    tipoRegistro, codigoVendedor, codigoCliente, controleCgc, nome, nomeFantasia, endereco, numero, complemento, bairro, cidade, estado, codigoEndPostal, digitoCodEndPostal, telComercial, telFax, regiaoVendas, nomeRegiaoVendas, rotaVisita, nomeRotaVisita, codigoMunicipio, codigoPais, codigoEstado, codigoAtividadeCliente, codigoCategoriaCliente, codigoRegiaoSeguro, codigoGrupoCliente, limiteCredito, formaPagamento, nomeContatoComercial, cpfCgc, email, percAcrescimoPreco, inscricaoEstadual, tipoBloqueio, descricaoBloqueio, tipoDocumento, situacao ");
                        query.AppendLine("from      Cliente ");
                        query.AppendLine("where     codigoVendedor = @codigo ");
                        query.AppendLine("          and (situacao <> 0) and tipoRegistro = '01'");

                        comando.CommandText = query.ToString();
                        comando.Parameters.Add("@codigo", SqlDbType.VarChar).Value = codigo;

                        DataTable dt = FabricaSql.GeraDataTable(comando);

                        List<InfoCliente> registros = new List<InfoCliente>();                        
                        foreach (DataRow row in dt.Rows)
                        {
                            registros.Add(new InfoCliente(row.Field<string>("tipoRegistro"), row.Field<string>("codigoVendedor"), row.Field<string>("codigoCliente"), row.Field<string>("controleCgc"), row.Field<string>("nome"), row.Field<string>("nomeFantasia"), row.Field<string>("endereco"), row.Field<string>("numero"), row.Field<string>("complemento"), row.Field<string>("bairro"), row.Field<string>("cidade"), row.Field<string>("estado"), row.Field<string>("codigoEndPostal"), row.Field<string>("digitoCodEndPostal"), row.Field<string>("telComercial"), row.Field<string>("telFax"), row.Field<string>("regiaoVendas"), row.Field<string>("nomeRegiaoVendas"), row.Field<string>("rotaVisita"), row.Field<string>("nomeRotaVisita"), row.Field<string>("codigoMunicipio"), row.Field<string>("codigoPais"), row.Field<string>("codigoEstado"), row.Field<string>("codigoAtividadeCliente"), row.Field<string>("codigoCategoriaCliente"), row.Field<string>("codigoRegiaoSeguro"), row.Field<string>("codigoGrupoCliente"), row.Field<Single>("limiteCredito"), row.Field<string>("formaPagamento"), row.Field<string>("nomeContatoComercial"), row.Field<string>("cpfCgc"), row.Field<string>("email"), row.Field<Single>("percAcrescimoPreco"), row.Field<string>("inscricaoEstadual"), row.Field<string>("tipoBloqueio"), row.Field<string>("descricaoBloqueio"), row.Field<string>("tipoDocumento"), row.Field<string>("situacao")));
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

        public static void Atualiza(InfoCliente[] clientes)
        {
            try
            {
                using (SqlConnection conexao = FabricaSql.NovaConexao())
                {
                    using (SqlCommand comando = FabricaSql.NovoComandoTexto(conexao))
                    {

                        foreach (var cliente in clientes)
                        {
                            if (cliente.Situacao == "1")    //Novo cliente
                            {
                                InserirDados(comando, cliente);
                            }
                            else if (cliente.Situacao == "2") //Cliente alterado
                            {
                                AlterarDados(comando, cliente);
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

        private static void InserirDados(SqlCommand comando, InfoCliente cliente)
        {
            var query = new StringBuilder();
            query.AppendLine("insert into Cliente (tipoRegistro, codigoVendedor, codigoCliente, controleCgc, nome, nomeFantasia, ");
            query.AppendLine("  endereco, numero, complemento, bairro, cidade, estado, codigoEndPostal, ");
            query.AppendLine("  digitoCodEndPostal, telComercial, telFax, regiaoVendas, nomeRegiaoVendas, ");
            query.AppendLine("  rotaVisita, nomeRotaVisita, codigoMunicipio, codigoPais, codigoEstado, ");
            query.AppendLine("  codigoAtividadeCliente, codigoCategoriaCliente, codigoRegiaoSeguro, ");
            query.AppendLine("  codigoGrupoCliente, limiteCredito, formaPagamento, nomeContatoComercial, cpfCgc, ");
            query.AppendLine("  email, percAcrescimoPreco, inscricaoEstadual, tipoBloqueio, descricaoBloqueio, ");
            query.AppendLine("  tipoDocumento, situacao) ");
            query.AppendLine("values (@tipoRegistro, @codigoVendedor, @codigoCliente, @controleCgc, @nome, @nomeFantasia, ");
            query.AppendLine("  @endereco, @numero, @complemento, @bairro, @cidade, @estado, @codigoEndPostal, ");
            query.AppendLine("  @digitoCodEndPostal, @telComercial, @telFax, @regiaoVendas, @nomeRegiaoVendas, ");
            query.AppendLine("  @rotaVisita, @nomeRotaVisita, @codigoMunicipio, @codigoPais, @codigoEstado, ");
            query.AppendLine("  @codigoAtividadeCliente, @codigoCategoriaCliente, @codigoRegiaoSeguro, ");
            query.AppendLine("  @codigoGrupoCliente, @limiteCredito, @formaPagamento, @nomeContatoComercial, @cpfCgc, ");
            query.AppendLine("  @email, @percAcrescimoPreco, @inscricaoEstadual, @tipoBloqueio, @descricaoBloqueio, ");
            query.AppendLine("  @tipoDocumento, @situacao); ");

            comando.Parameters.Clear();
            comando.Parameters.Add("@tipoRegistro", SqlDbType.VarChar).Value = "4";
            comando.Parameters.Add("@codigoVendedor", SqlDbType.VarChar).Value = Funcoes.RemoveSimbolos(cliente.CodigoVendedor);
            comando.Parameters.Add("@codigoCliente", SqlDbType.VarChar).Value = Funcoes.RemoveSimbolos(cliente.CodigoCliente);
            comando.Parameters.Add("@controleCgc", SqlDbType.VarChar).Value = Funcoes.RemoveSimbolos(cliente.ControleCgc);
            comando.Parameters.Add("@nome", SqlDbType.VarChar).Value = Funcoes.RemoveSimbolos(cliente.NomeCliente);
            comando.Parameters.Add("@nomeFantasia", SqlDbType.VarChar).Value = Funcoes.RemoveSimbolos(cliente.NomeFantasia);
            comando.Parameters.Add("@endereco", SqlDbType.VarChar).Value = Funcoes.RemoveSimbolos(cliente.Endereco);
            comando.Parameters.Add("@numero", SqlDbType.VarChar).Value = Funcoes.RemoveSimbolos(cliente.NumeroEndereco);
            comando.Parameters.Add("@complemento", SqlDbType.VarChar).Value = Funcoes.RemoveSimbolos(cliente.Complemento);
            comando.Parameters.Add("@bairro", SqlDbType.VarChar).Value = Funcoes.RemoveSimbolos(cliente.Bairro);
            comando.Parameters.Add("@cidade", SqlDbType.VarChar).Value = Funcoes.RemoveSimbolos(cliente.Cidade);
            comando.Parameters.Add("@estado", SqlDbType.VarChar).Value = Funcoes.RemoveSimbolos(cliente.Estado);
            comando.Parameters.Add("@codigoEndPostal", SqlDbType.VarChar).Value = Funcoes.RemoveSimbolos(cliente.CEP);
            comando.Parameters.Add("@digitoCodEndPostal", SqlDbType.VarChar).Value = Funcoes.RemoveSimbolos(cliente.DigitoCEP);
            comando.Parameters.Add("@telComercial", SqlDbType.VarChar).Value = Funcoes.RemoveSimbolos(cliente.TelComercial);
            comando.Parameters.Add("@telFax", SqlDbType.VarChar).Value = Funcoes.RemoveSimbolos(cliente.TelFax);
            comando.Parameters.Add("@regiaoVendas", SqlDbType.VarChar).Value = Funcoes.RemoveSimbolos(cliente.RegiaoVendas);
            comando.Parameters.Add("@nomeRegiaoVendas", SqlDbType.VarChar).Value = Funcoes.RemoveSimbolos(cliente.NomeRegiaoVendas);
            comando.Parameters.Add("@rotaVisita", SqlDbType.VarChar).Value = Funcoes.RemoveSimbolos(cliente.RotaVisita);
            comando.Parameters.Add("@nomeRotaVisita", SqlDbType.VarChar).Value = Funcoes.RemoveSimbolos(cliente.NomeRotaVisita);
            comando.Parameters.Add("@codigoMunicipio", SqlDbType.VarChar).Value = Funcoes.RemoveSimbolos(cliente.CodigoMunicipio);
            comando.Parameters.Add("@codigoPais", SqlDbType.VarChar).Value = Funcoes.RemoveSimbolos(cliente.CodigoPais);
            comando.Parameters.Add("@codigoEstado", SqlDbType.VarChar).Value = Funcoes.RemoveSimbolos(cliente.CodigoEstado);
            comando.Parameters.Add("@codigoAtividadeCliente", SqlDbType.VarChar).Value = Funcoes.RemoveSimbolos(cliente.CodigoAtividadeCliente);
            comando.Parameters.Add("@codigoCategoriaCliente", SqlDbType.VarChar).Value = Funcoes.RemoveSimbolos(cliente.CodigoCategoriaCliente);
            comando.Parameters.Add("@codigoRegiaoSeguro", SqlDbType.VarChar).Value = Funcoes.RemoveSimbolos(cliente.CodigoRegiaoSeguro);
            comando.Parameters.Add("@codigoGrupoCliente", SqlDbType.VarChar).Value = Funcoes.RemoveSimbolos(cliente.CodigoGrupoCliente);
            comando.Parameters.Add("@limiteCredito", SqlDbType.Real).Value = cliente.LimiteCredito;
            comando.Parameters.Add("@formaPagamento", SqlDbType.VarChar).Value = Funcoes.RemoveSimbolos(cliente.FormaPagamento);
            comando.Parameters.Add("@nomeContatoComercial", SqlDbType.VarChar).Value = Funcoes.RemoveSimbolos(cliente.NomeContatoComercial);
            comando.Parameters.Add("@cpfCgc", SqlDbType.VarChar).Value = Funcoes.RemoveSimbolos(cliente.CpfCgc);
            comando.Parameters.Add("@email", SqlDbType.VarChar).Value = Funcoes.RemoveSimbolos(cliente.Email);
            comando.Parameters.Add("@percAcrescimoPreco", SqlDbType.Real).Value = cliente.PercAcrescimo;
            comando.Parameters.Add("@inscricaoEstadual", SqlDbType.VarChar).Value = Funcoes.RemoveSimbolos(cliente.InscricaoEstadual);
            comando.Parameters.Add("@tipoBloqueio", SqlDbType.VarChar).Value = Funcoes.RemoveSimbolos(cliente.TipoBloqueio);
            comando.Parameters.Add("@descricaoBloqueio", SqlDbType.VarChar).Value = Funcoes.RemoveSimbolos(cliente.DescricaoBloqueio);
            comando.Parameters.Add("@tipoDocumento", SqlDbType.VarChar).Value = Funcoes.RemoveSimbolos(cliente.TipoDocumento);
            comando.Parameters.Add("@situacao", SqlDbType.VarChar).Value = cliente.Situacao;

            comando.CommandText = query.ToString();
            comando.ExecuteNonQuery();
        }

        public static void AlterarDados(SqlCommand comando, InfoCliente cliente)
        {
            var query = new StringBuilder();
            query.AppendLine("update Cliente ");
            query.AppendLine("set   tipoRegistro = @tipoRegistro, ");
            query.AppendLine("      codigoVendedor = @codigoVendedor, ");
            query.AppendLine("      codigoCliente = @codigoCliente, ");
            query.AppendLine("      controleCgc = @controleCgc, ");
            query.AppendLine("      nome = @nome, ");
            query.AppendLine("      nomeFantasia = @nomeFantasia, ");
            query.AppendLine("      endereco = @endereco, ");
            query.AppendLine("      numero = @numero, ");
            query.AppendLine("      complemento = @complemento, ");
            query.AppendLine("      bairro = @bairro, ");
            query.AppendLine("      cidade = @cidade, ");
            query.AppendLine("      estado = @estado, ");
            query.AppendLine("      codigoEndPostal = @codigoEndPostal, ");
            query.AppendLine("      digitoCodEndPostal = @digitoCodEndPostal, ");
            query.AppendLine("      telComercial = @telComercial, ");
            query.AppendLine("      telFax = @telFax, ");
            query.AppendLine("      regiaoVendas = @regiaoVendas, ");
            query.AppendLine("      nomeRegiaoVendas = @nomeRegiaoVendas, ");
            query.AppendLine("      rotaVisita = @rotaVisita, ");
            query.AppendLine("      nomeRotaVisita = @nomeRotaVisita, ");
            query.AppendLine("      codigoMunicipio = @codigoMunicipio, ");
            query.AppendLine("      codigoPais = @codigoPais, ");
            query.AppendLine("      codigoEstado = @codigoEstado, ");
            query.AppendLine("      codigoAtividadeCliente = @codigoAtividadeCliente, ");
            query.AppendLine("      codigoCategoriaCliente = @codigoCategoriaCliente, ");
            query.AppendLine("      codigoRegiaoSeguro = @codigoRegiaoSeguro, ");
            query.AppendLine("      codigoGrupoCliente = @codigoGrupoCliente, ");
            query.AppendLine("      limiteCredito = @limiteCredito, ");
            query.AppendLine("      formaPagamento = @formaPagamento, ");
            query.AppendLine("      nomeContatoComercial = @nomeContatoComercial, ");
            query.AppendLine("      cpfCgc = @cpfCgc, ");
            query.AppendLine("      email = @email, ");
            query.AppendLine("      percAcrescimoPreco = @percAcrescimoPreco, ");
            query.AppendLine("      inscricaoEstadual = @inscricaoEstadual, ");
            query.AppendLine("      tipoBloqueio = @tipoBloqueio, ");
            query.AppendLine("      descricaoBloqueio = @descricaoBloqueio, ");
            query.AppendLine("      tipoDocumento = @tipoDocumento, ");
            query.AppendLine("      situacao = @situacao ");
            query.AppendLine("where codigoCliente = @codigoCliente ");
            query.AppendLine("       and controleCgc = @controleCgc; ");

            comando.Parameters.Clear();
            comando.Parameters.Add("@tipoRegistro", SqlDbType.VarChar).Value = "4";
            comando.Parameters.Add("@codigoVendedor", SqlDbType.VarChar).Value = Funcoes.RemoveSimbolos(cliente.CodigoVendedor);
            comando.Parameters.Add("@codigoCliente", SqlDbType.VarChar).Value = Funcoes.RemoveSimbolos(cliente.CodigoCliente);
            comando.Parameters.Add("@controleCgc", SqlDbType.VarChar).Value = Funcoes.RemoveSimbolos(cliente.ControleCgc);
            comando.Parameters.Add("@nome", SqlDbType.VarChar).Value = Funcoes.RemoveSimbolos(cliente.NomeCliente);
            comando.Parameters.Add("@nomeFantasia", SqlDbType.VarChar).Value = Funcoes.RemoveSimbolos(cliente.NomeFantasia);
            comando.Parameters.Add("@endereco", SqlDbType.VarChar).Value = Funcoes.RemoveSimbolos(cliente.Endereco);
            comando.Parameters.Add("@numero", SqlDbType.VarChar).Value = Funcoes.RemoveSimbolos(cliente.NumeroEndereco);
            comando.Parameters.Add("@complemento", SqlDbType.VarChar).Value = Funcoes.RemoveSimbolos(cliente.Complemento);
            comando.Parameters.Add("@bairro", SqlDbType.VarChar).Value = Funcoes.RemoveSimbolos(cliente.Bairro);
            comando.Parameters.Add("@cidade", SqlDbType.VarChar).Value = Funcoes.RemoveSimbolos(cliente.Cidade);
            comando.Parameters.Add("@estado", SqlDbType.VarChar).Value = Funcoes.RemoveSimbolos(cliente.Estado);
            comando.Parameters.Add("@codigoEndPostal", SqlDbType.VarChar).Value = Funcoes.RemoveSimbolos(cliente.CEP);
            comando.Parameters.Add("@digitoCodEndPostal", SqlDbType.VarChar).Value = Funcoes.RemoveSimbolos(cliente.DigitoCEP);
            comando.Parameters.Add("@telComercial", SqlDbType.VarChar).Value = Funcoes.RemoveSimbolos(cliente.TelComercial);
            comando.Parameters.Add("@telFax", SqlDbType.VarChar).Value = Funcoes.RemoveSimbolos(cliente.TelFax);
            comando.Parameters.Add("@regiaoVendas", SqlDbType.VarChar).Value = Funcoes.RemoveSimbolos(cliente.RegiaoVendas);
            comando.Parameters.Add("@nomeRegiaoVendas", SqlDbType.VarChar).Value = Funcoes.RemoveSimbolos(cliente.NomeRegiaoVendas);
            comando.Parameters.Add("@rotaVisita", SqlDbType.VarChar).Value = Funcoes.RemoveSimbolos(cliente.RotaVisita);
            comando.Parameters.Add("@nomeRotaVisita", SqlDbType.VarChar).Value = Funcoes.RemoveSimbolos(cliente.NomeRotaVisita);
            comando.Parameters.Add("@codigoMunicipio", SqlDbType.VarChar).Value = Funcoes.RemoveSimbolos(cliente.CodigoMunicipio);
            comando.Parameters.Add("@codigoPais", SqlDbType.VarChar).Value = Funcoes.RemoveSimbolos(cliente.CodigoPais);
            comando.Parameters.Add("@codigoEstado", SqlDbType.VarChar).Value = Funcoes.RemoveSimbolos(cliente.CodigoEstado);
            comando.Parameters.Add("@codigoAtividadeCliente", SqlDbType.VarChar).Value = Funcoes.RemoveSimbolos(cliente.CodigoAtividadeCliente);
            comando.Parameters.Add("@codigoCategoriaCliente", SqlDbType.VarChar).Value = Funcoes.RemoveSimbolos(cliente.CodigoCategoriaCliente);
            comando.Parameters.Add("@codigoRegiaoSeguro", SqlDbType.VarChar).Value = Funcoes.RemoveSimbolos(cliente.CodigoRegiaoSeguro);
            comando.Parameters.Add("@codigoGrupoCliente", SqlDbType.VarChar).Value = Funcoes.RemoveSimbolos(cliente.CodigoGrupoCliente);
            comando.Parameters.Add("@limiteCredito", SqlDbType.Real).Value = cliente.LimiteCredito;
            comando.Parameters.Add("@formaPagamento", SqlDbType.VarChar).Value = Funcoes.RemoveSimbolos(cliente.FormaPagamento);
            comando.Parameters.Add("@nomeContatoComercial", SqlDbType.VarChar).Value = Funcoes.RemoveSimbolos(cliente.NomeContatoComercial);
            comando.Parameters.Add("@cpfCgc", SqlDbType.VarChar).Value = Funcoes.RemoveSimbolos(cliente.CpfCgc);
            comando.Parameters.Add("@email", SqlDbType.VarChar).Value = Funcoes.RemoveSimbolos(cliente.Email);
            comando.Parameters.Add("@percAcrescimoPreco", SqlDbType.Real).Value = cliente.PercAcrescimo;
            comando.Parameters.Add("@inscricaoEstadual", SqlDbType.VarChar).Value = Funcoes.RemoveSimbolos(cliente.InscricaoEstadual);
            comando.Parameters.Add("@tipoBloqueio", SqlDbType.VarChar).Value = Funcoes.RemoveSimbolos(cliente.TipoBloqueio);
            comando.Parameters.Add("@descricaoBloqueio", SqlDbType.VarChar).Value = Funcoes.RemoveSimbolos(cliente.DescricaoBloqueio);
            comando.Parameters.Add("@tipoDocumento", SqlDbType.VarChar).Value = Funcoes.RemoveSimbolos(cliente.TipoDocumento);
            comando.Parameters.Add("@situacao", SqlDbType.Int).Value = cliente.Situacao;

            comando.CommandText = query.ToString();
            comando.ExecuteNonQuery();                
        }
    }
}