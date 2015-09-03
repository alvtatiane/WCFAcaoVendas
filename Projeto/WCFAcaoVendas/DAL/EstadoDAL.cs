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
    public abstract class EstadoDAL
    {
        public static Estado[] BuscarDados()
        {
            try
            {
                using (SqlConnection conexao = FabricaSql.NovaConexao())
                {
                    using (SqlCommand comando = FabricaSql.NovoComandoTexto(conexao))
                    {
                        var query = new StringBuilder();
                        query.AppendLine("select    e.tipoRegistro, e.codigoEstado, e.nomeEstado, e.uf, e.situacao ");
                        query.AppendLine("from      Estado e ");
                        query.AppendLine("where     e.situacao <> 0 ; ");

                        comando.CommandText = query.ToString();

                        DataTable dt = FabricaSql.GeraDataTable(comando);

                        List<Estado> registros = new List<Estado>();
                        foreach (DataRow row in dt.Rows)
                        {
                            registros.Add(new Estado(row.Field<string>("tipoRegistro"), row.Field<string>("codigoEstado"), row.Field<string>("nomeEstado"), row.Field<string>("uf"), row.Field<string>("situacao")));
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