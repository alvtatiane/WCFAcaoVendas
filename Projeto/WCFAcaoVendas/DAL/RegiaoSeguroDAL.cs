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
    public abstract class RegiaoSeguroDAL
    {
        public static RegiaoSeguro[] BuscarDados()
        {
            try
            {
                using (SqlConnection conexao = FabricaSql.NovaConexao())
                {
                    using (SqlCommand comando = FabricaSql.NovoComandoTexto(conexao))
                    {
                        var query = new StringBuilder();
                        query.AppendLine("select    r.tipoRegistro, r.codigoRegiaoSeguro, r.nomeRegiaoSeguro, r.estadoRegiaoSeguro, r.situacao ");
                        query.AppendLine("from      RegiaoSeguro r ");
                        query.AppendLine("where     r.situacao <> 0 ; ");

                        comando.CommandText = query.ToString();

                        DataTable dt = FabricaSql.GeraDataTable(comando);

                        List<RegiaoSeguro> registros = new List<RegiaoSeguro>();
                        foreach (DataRow row in dt.Rows)
                        {
                            registros.Add(new RegiaoSeguro(row.Field<string>("tipoRegistro"), row.Field<string>("codigoRegiaoSeguro"), row.Field<string>("nomeRegiaoSeguro"), row.Field<string>("estadoRegiaoSeguro"), row.Field<string>("situacao")));
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