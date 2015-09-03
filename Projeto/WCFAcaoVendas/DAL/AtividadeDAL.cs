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
    public abstract class AtividadeDAL
    {
        public static Atividade[] BuscarDados()
        {
            try
            {
                using (SqlConnection conexao = FabricaSql.NovaConexao())
                {
                    using (SqlCommand comando = FabricaSql.NovoComandoTexto(conexao))
                    {
                        var query = new StringBuilder();
                        query.AppendLine("select    a.tipoRegistro, a.codigoAtividade, a.nomeAtividade, a.situacao ");
                        query.AppendLine("from      Atividade a "); 
                        query.AppendLine("where     a.situacao <> 0; ");

                        comando.CommandText = query.ToString();

                        DataTable dt = FabricaSql.GeraDataTable(comando);

                        List<Atividade> registros = new List<Atividade>();
                        foreach (DataRow row in dt.Rows)
                        {
                            registros.Add(new Atividade(row.Field<string>("tipoRegistro"), row.Field<string>("codigoAtividade"), row.Field<string>("nomeAtividade"), row.Field<string>("situacao")));
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