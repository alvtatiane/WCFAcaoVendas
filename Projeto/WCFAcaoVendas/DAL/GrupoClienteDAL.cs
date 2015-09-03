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
    public abstract class GrupoClienteDAL
    {
        public static GrupoCliente[] BuscarDados()
        {
            try
            {
                using (SqlConnection conexao = FabricaSql.NovaConexao())
                {
                    using (SqlCommand comando = FabricaSql.NovoComandoTexto(conexao))
                    {
                        var query = new StringBuilder();
                        query.AppendLine("select    g.tipoRegistro, g.codigoGrupo, g.nomeGrupo, g.situacao ");
                        query.AppendLine("from      GrupoCliente g ");
                        query.AppendLine("where     g.situacao <> 0; ");

                        comando.CommandText = query.ToString();

                        DataTable dt = FabricaSql.GeraDataTable(comando);

                        List<GrupoCliente> registros = new List<GrupoCliente>();
                        foreach (DataRow row in dt.Rows)
                        {
                            registros.Add(new GrupoCliente(row.Field<string>("tipoRegistro"), row.Field<string>("codigoGrupo"), row.Field<string>("nomeGrupo"), row.Field<string>("situacao")));
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