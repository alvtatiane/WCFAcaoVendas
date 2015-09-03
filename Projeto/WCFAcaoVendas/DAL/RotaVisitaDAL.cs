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
    public abstract class RotaVisitaDAL
    {
        public static RotaVisita[] BuscarDados()
        {
            try
            {
                using (SqlConnection conexao = FabricaSql.NovaConexao())
                {
                    using (SqlCommand comando = FabricaSql.NovoComandoTexto(conexao))
                    {
                        var query = new StringBuilder();
                        query.AppendLine("select    r.tipoRegistro, r.codigoRota, r.nomeRota, r.cidadeRota, r.estadoRota, r.situacao ");
                        query.AppendLine("from      RotaVisita r ");
                        query.AppendLine("where     r.situacao <> 0 ; ");

                        comando.CommandText = query.ToString();

                        DataTable dt = FabricaSql.GeraDataTable(comando);

                        List<RotaVisita> registros = new List<RotaVisita>();
                        foreach (DataRow row in dt.Rows)
                        {
                            registros.Add(new RotaVisita(row.Field<string>("tipoRegistro"), row.Field<string>("codigoRota"), row.Field<string>("nomeRota"), row.Field<string>("cidadeRota"), row.Field<string>("estadoRota"), row.Field<string>("situacao")));
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