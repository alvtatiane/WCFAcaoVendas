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
    public abstract class MunicipioDAL
    {
        public static Municipio[] BuscarDados()
        {
            try
            {
                using (SqlConnection conexao = FabricaSql.NovaConexao())
                {
                    using (SqlCommand comando = FabricaSql.NovoComandoTexto(conexao))
                    {
                        var query = new StringBuilder();
                        query.AppendLine("select    m.tipoRegistro, m.codigoMunicipio, m.nomeMunicipio, m.uf, m.situacao ");
                        query.AppendLine("from      Municipio m ");
                        query.AppendLine("where     m.situacao <> 0 ; ");

                        comando.CommandText = query.ToString();

                        DataTable dt = FabricaSql.GeraDataTable(comando);

                        List<Municipio> registros = new List<Municipio>();
                        foreach (DataRow row in dt.Rows)
                        {
                            registros.Add(new Municipio(row.Field<string>("tipoRegistro"), row.Field<string>("codigoMunicipio"), row.Field<string>("nomeMunicipio"), row.Field<string>("uf"), row.Field<string>("situacao")));
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