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
    public abstract class GeralDAL
    {
        public static string BuscaNomeVendedor(string codigo)
        {
            try
            {
                using (SqlConnection conexao = FabricaSql.NovaConexao())
                {
                    using (SqlCommand comando = FabricaSql.NovoComandoTexto(conexao))
                    {
                        var query = new StringBuilder();
                        query.AppendLine("select    l.nomeVendedor ");
                        query.AppendLine("from      Login l ");
                        query.AppendLine("where     l.codigoVendedor = @codigo; ");

                        comando.CommandText = query.ToString();
                        comando.Parameters.Add("@codigo", SqlDbType.VarChar).Value = codigo;

                        DataTable dt = FabricaSql.GeraDataTable(comando);

                        return dt.Rows[0].Field<string>("nomeVendedor");

                    }
                }
            }
            catch (Exception exception)
            {
                //LogErro.Registrar(exception.Message);
                throw;
            }
        }

        public static InfoCliente BuscaNomeCliente(string codigo)
        {
            try
            {
                using (SqlConnection conexao = FabricaSql.NovaConexao())
                {
                    using (SqlCommand comando = FabricaSql.NovoComandoTexto(conexao))
                    {
                        var query = new StringBuilder();
                        query.AppendLine("select    c.nome, c.email ");
                        query.AppendLine("from      Cliente c ");
                        query.AppendLine("where     c.codigoCliente = @codigo ");

                        comando.CommandText = query.ToString();
                        comando.Parameters.Add("@codigo", SqlDbType.VarChar).Value = codigo;

                        DataTable dt = FabricaSql.GeraDataTable(comando);

                        InfoCliente info = new InfoCliente(null, null, null, null, null, dt.Rows[0].Field<string>("nome"), null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, 0, null, null, null, dt.Rows[0].Field<string>("email"), 0, null, null, null, null, null);

                        return info;

                    }
                }
            }
            catch (Exception exception)
            {
                //LogErro.Registrar(exception.Message);
                throw;
            }
        }

        public static string BuscaNomeCidade(string codigo)
        {
            try
            {
                using (SqlConnection conexao = FabricaSql.NovaConexao())
                {
                    using (SqlCommand comando = FabricaSql.NovoComandoTexto(conexao))
                    {
                        var query = new StringBuilder();
                        query.AppendLine("select    m.nomeMunicipio ");
                        query.AppendLine("from      Municipio m ");
                        query.AppendLine("where     m.codigoMunicipio = @codigo; ");

                        comando.CommandText = query.ToString();
                        comando.Parameters.Add("@codigo", SqlDbType.VarChar).Value = codigo;

                        DataTable dt = FabricaSql.GeraDataTable(comando);

                        return dt.Rows[0].Field<string>("nomeMunicipio");

                    }
                }
            }
            catch (Exception exception)
            {
                //LogErro.Registrar(exception.Message);
                throw;
            }
        }

        public static string BuscaNomeProduto(string codigo)
        {
            try
            {
                using (SqlConnection conexao = FabricaSql.NovaConexao())
                {
                    using (SqlCommand comando = FabricaSql.NovoComandoTexto(conexao))
                    {
                        var query = new StringBuilder();
                        query.AppendLine("select    p.nomeProduto ");
                        query.AppendLine("from      Produto p ");
                        query.AppendLine("where     p.codigoProduto = @codigo; ");

                        comando.CommandText = query.ToString();
                        comando.Parameters.Add("@codigo", SqlDbType.VarChar).Value = codigo;

                        DataTable dt = FabricaSql.GeraDataTable(comando);

                        return dt.Rows[0].Field<string>("nomeProduto");

                    }
                }
            }
            catch (Exception exception)
            {
                //LogErro.Registrar(exception.Message);
                throw;
            }
        }
    }
}