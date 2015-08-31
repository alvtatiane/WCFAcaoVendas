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
    public abstract class LoginDAL
    {
        public static void Atualiza(InfoLoginVendedor infoLogin)
        {
            try
            {
                using (SqlConnection conexao = FabricaSql.NovaConexao())
                {
                    using (SqlCommand comando = FabricaSql.NovoComandoTexto(conexao))
                    {
                        var deletado = VerificaSituacaoCodigoVendedor(comando, infoLogin); //Esse metodo verifica se o login a ser cadastrado já nao existe e por algum caso tenho sido deletado, logo ele nao pode permitir o cadastro.

                        if (deletado == false)
                        {
                            if (infoLogin.Situacao == "1")    //Novo login
                            {
                                InserirDados(comando, infoLogin);
                            }
                            else if (infoLogin.Situacao == "2") //Login alterado
                            {
                                AlterarDados(comando, infoLogin);
                            }
                            else
                            {
                                throw new Exception("Campo situação não encontrado.");
                            }
                        }
                        else
                        {
                            throw new Exception("Esse código de vendedor não pode ser cadastrado/alterado pois o mesmo foi deletado pela empresa. Entre em contato com sua empresa.");
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                //LogErro.Registrar(exception.Message);
                throw;
            }

        }

        private static void AlterarDados(SqlCommand comando, InfoLoginVendedor infoLogin)
        {
            var query = new StringBuilder();
            query.AppendLine("update    Login ");
            query.AppendLine("set       nomeVendedor = @nomeVendedor, ");
            query.AppendLine("          filial = @filial, ");
            query.AppendLine("          login = @login, ");
            query.AppendLine("          senha = @senha, ");
            query.AppendLine("          numUltimoPedido = @numUltimoPedido, ");
            query.AppendLine("          versaoSoftware = @versaoSoftware, ");
            query.AppendLine("          numSerieAparelho = @numSerieAparelho, ");
            query.AppendLine("          atualizado = @atualizado, ");
            query.AppendLine("          situacao = @situacao ");
            query.AppendLine("where     codigoVendedor = @codigoVendedor; ");

            comando.Parameters.Clear();
            comando.CommandText = query.ToString();
            comando.Parameters.Add("@codigoVendedor", SqlDbType.VarChar).Value = infoLogin.CodigoVendedor;
            comando.Parameters.Add("@nomeVendedor", SqlDbType.VarChar).Value = infoLogin.NomeVendedor;
            comando.Parameters.Add("@filial", SqlDbType.VarChar).Value = infoLogin.Filial;
            comando.Parameters.Add("@login", SqlDbType.VarChar).Value = infoLogin.Login;
            comando.Parameters.Add("@senha", SqlDbType.VarChar).Value = infoLogin.Senha;
            comando.Parameters.Add("@numUltimoPedido", SqlDbType.VarChar).Value = infoLogin.NumUltimoPedido;
            comando.Parameters.Add("@versaoSoftware", SqlDbType.VarChar).Value = infoLogin.VersaoSoftware;
            comando.Parameters.Add("@numSerieAparelho", SqlDbType.VarChar).Value = infoLogin.NumSerieAparelho;
            comando.Parameters.Add("@atualizado", SqlDbType.Int).Value = infoLogin.Atualizado;
            comando.Parameters.Add("@situacao", SqlDbType.VarChar).Value = infoLogin.Situacao;

            comando.ExecuteNonQuery();

        }

        private static void InserirDados(SqlCommand comando, InfoLoginVendedor infoLogin)
        {
            var query = new StringBuilder();
            query.AppendLine("insert into   Login(codigoVendedor, nomeVendedor, filial, login, senha, numUltimoPedido, ");
            query.AppendLine("versaoSoftware, numSerieAparelho, atualizado, situacao) ");
            query.AppendLine("values(@codigoVendedor, @nomeVendedor, @filial, @login, @senha, '0', ");
            query.AppendLine("@versaoSoftware, @numSerieAparelho, 0, @situacao); ");
            //Insere o usuario e marca ele como nao atualizado e inicializa o valor do ultimo pedido dele, no caso 0 pois nunca houve pedido antes.

            comando.Parameters.Clear();
            comando.CommandText = query.ToString();
            comando.Parameters.Add("@codigoVendedor", SqlDbType.VarChar).Value = infoLogin.CodigoVendedor;
            comando.Parameters.Add("@nomeVendedor", SqlDbType.VarChar).Value = infoLogin.NomeVendedor;
            comando.Parameters.Add("@filial", SqlDbType.VarChar).Value = infoLogin.Filial;
            comando.Parameters.Add("@login", SqlDbType.VarChar).Value = infoLogin.Login;
            comando.Parameters.Add("@senha", SqlDbType.VarChar).Value = infoLogin.Senha;
            comando.Parameters.Add("@numUltimoPedido", SqlDbType.VarChar).Value = infoLogin.NumUltimoPedido;
            comando.Parameters.Add("@versaoSoftware", SqlDbType.VarChar).Value = infoLogin.VersaoSoftware;
            comando.Parameters.Add("@numSerieAparelho", SqlDbType.VarChar).Value = infoLogin.NumSerieAparelho;
            comando.Parameters.Add("@atualizado", SqlDbType.Int).Value = infoLogin.Atualizado;
            comando.Parameters.Add("@situacao", SqlDbType.VarChar).Value = infoLogin.Situacao;

            comando.ExecuteNonQuery();

        }

        public static bool VerificaSituacaoCodigoVendedor(SqlCommand comando, InfoLoginVendedor infoLogin)
        {
            var query = new StringBuilder();
            query.AppendLine("select    l.situacao ");
            query.AppendLine("from      Login l ");
            query.AppendLine("where     l.codigoVendedor = @codigoVendedor; ");

            comando.CommandText = query.ToString();
            comando.Parameters.Add("@codigoVendedor", SqlDbType.VarChar).Value = infoLogin.CodigoVendedor;

            DataTable dt = FabricaSql.GeraDataTable(comando);

            if (dt.Rows.Count < 1)
            {
                return false;
            }

            if (dt.Rows[0].Field<string>("situacao") == "3") //Se o campo situacao for igual a 3 entao esse usuario foi deletado pelo sistema ERP
            {
                return true;
            }
            return false;
        }
    }
}