using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

namespace WCFAcaoVendas.DAL
{
    public abstract class SoftwareDAL
    {
        public static string BuscarDados(string numeroVersao)
        {
            try
            {
                using (SqlConnection conexao = FabricaSql.NovaConexao())
                {
                    using (SqlCommand comando = FabricaSql.NovoComandoTexto(conexao))
                    {
                        var query = new StringBuilder();
                        query.AppendLine("select    vs.numeroVersao, vs.link ");
                        query.AppendLine("from      VersoesSoftware vs ");
                        query.AppendLine("where     vs.id = (Select MAX(id) from VersoesSoftware);");

                        comando.CommandText = query.ToString();

                        DataTable dt = FabricaSql.GeraDataTable(comando);

                        if (dt.Rows.Count < 1)
                        {
                            return null;
                        }

                        if (dt.Rows[0].Field<string>("numeroVersao") > numeroVersao)
                        {
                            return dt.Rows[0].Field<string>("link");
                        }
                        return null;  
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