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
    public abstract class DesdobramentoFaturamentoDAL
    {
        public static InfoDesdobramentoFaturamento[] BuscarDados(string codigo)
        {
            try
            {
                using (SqlConnection conexao = FabricaSql.NovaConexao())
                {
                    using (SqlCommand comando = FabricaSql.NovoComandoTexto(conexao))
                    {
                        var query = new StringBuilder();
                        query.AppendLine("select    d.tipoRegistro, d.situacao ");
                        query.AppendLine("from      DesdobramentoFatura d ");
                        query.AppendLine("where     d.codigoVendedor = @codigo ");
                        query.AppendLine("          and (d.situacao <> 0) and d.tipoRegistro = '07'; ");

                        comando.CommandText = query.ToString();
                        comando.Parameters.Add("@codigo", SqlDbType.VarChar).Value = codigo;

                        DataTable dt = FabricaSql.GeraDataTable(comando);

                        List<InfoDesdobramentoFaturamento> registros = new List<InfoDesdobramentoFaturamento>();
                        foreach (DataRow row in dt.Rows)
                        {
                            registros.Add(new InfoDesdobramentoFaturamento(row.Field<string>("tipoRegistro"), null, null, null, null, null, null, null, null, null, null, 0, null, row.Field<string>("situacao")));
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