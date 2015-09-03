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
    public abstract class RegiaoVendaDAL
    {
        public static RegiaoVenda[] BuscarDados()
        {
            try
            {
                using (SqlConnection conexao = FabricaSql.NovaConexao())
                {
                    using (SqlCommand comando = FabricaSql.NovoComandoTexto(conexao))
                    {
                        var query = new StringBuilder();
                        query.AppendLine("select    r.tipoRegistro, r.codigoRegiao, r.nomeRegiao, r.cidadeRegiao, r.estadoRegiao, r.situacao ");
                        query.AppendLine("from      RegiaoVendas r ");
                        query.AppendLine("where     r.situacao <> 0 ; ");

                        comando.CommandText = query.ToString();

                        DataTable dt = FabricaSql.GeraDataTable(comando);

                        List<RegiaoVenda> registros = new List<RegiaoVenda>();
                        foreach (DataRow row in dt.Rows)
                        {
                            registros.Add(new RegiaoVenda(row.Field<string>("tipoRegistro"), row.Field<string>("codigoRegiao"), row.Field<string>("nomeRegiao"), row.Field<string>("cidadeRegiao"), row.Field<string>("estadoRegiao"), row.Field<string>("situacao")));
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