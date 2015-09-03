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
    public abstract class PaisDAL
    {
        public static Pais[] BuscarDados()
        {
            try
            {
                using (SqlConnection conexao = FabricaSql.NovaConexao())
                {
                    using (SqlCommand comando = FabricaSql.NovoComandoTexto(conexao))
                    {
                        var query = new StringBuilder();
                        query.AppendLine("select    p.tipoRegistro, p.codigoPais, p.nomePais, p.situacao ");
                        query.AppendLine("from      Pais p ");
                        query.AppendLine("where     p.situacao <> 0 ; ");

                        comando.CommandText = query.ToString();

                        DataTable dt = FabricaSql.GeraDataTable(comando);

                        List<Pais> registros = new List<Pais>();
                        foreach (DataRow row in dt.Rows)
                        {
                            registros.Add(new Pais(row.Field<string>("tipoRegistro"), row.Field<string>("codigoPais"), row.Field<string>("nomePais"), row.Field<string>("situacao")));
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
    }
}