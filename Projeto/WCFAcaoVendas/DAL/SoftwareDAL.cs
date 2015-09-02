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

                        if (ComparaVersao(dt.Rows[0].Field<string>("numeroVersao"), numeroVersao))
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

        private static bool ComparaVersao(string v, string numeroVersao)
        {
            int nB1, nB2, nB3;
            int nA1, nA2, nA3;

            SeparaValores(numeroVersao, out nA1, out nA2, out nA3);
            SeparaValores(v, out nB1, out nB2, out nB3);

            if (nB1 > nA1)
            {
                return true;
            }
            else if (nB1 == nA1)
            {
                if (nB2 > nA2)
                {
                    return true;
                }
                else if (nB2 == nA2)
                {
                    if (nB3 > nA3)
                    {
                        return true;
                    }
                    return false;
                }
                else
                {
                    return false;
                }
            }

            return false;
            
        }

        private static void SeparaValores(string numeroVersao, out int n1, out int n2, out int n3)
        {
            var numeros = numeroVersao.Split('.');
            n1 = int.Parse(numeros[0]);
            n2 = int.Parse(numeros[1]);
            n3 = int.Parse(numeros[2]);
        }
    }
}