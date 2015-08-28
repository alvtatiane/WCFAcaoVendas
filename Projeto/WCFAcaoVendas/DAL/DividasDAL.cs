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
    public abstract class DividasDAL
    {
        public static InfoDivida[] BuscarDados(string codigo)
        {
            try
            {
                using (SqlConnection conexao = FabricaSql.NovaConexao())
                {
                    using (SqlCommand comando = FabricaSql.NovoComandoTexto(conexao))
                    {
                        var query = new StringBuilder();
                        query.AppendLine("select    d.tipoRegistro, d.filial, d.modeloDocFiscal, d.numeroDuplicata, d.numeroParcela, d.codigoCliente, d.controlecgc, d.dtVencimento, d.saldoTitulo, d.numPedidoAndroid, d.situacao ");
                        query.AppendLine("from      Cliente c ");
                        query.AppendLine("          left join Dividas d ");
                        query.AppendLine("          on c.codigoCliente = d.codigoCliente and c.controleCgc= d.controleCgc ");
                        query.AppendLine("where     c.codigoVendedor = @codigo ");
                        query.AppendLine("          and (d.situacao <> 0) and d.tipoRegistro = '03'; ");

                        comando.CommandText = query.ToString();
                        comando.Parameters.Add("@codigo", SqlDbType.VarChar).Value = codigo;

                        DataTable dt = FabricaSql.GeraDataTable(comando);

                        List<InfoDivida> registros = new List<InfoDivida>();
                        foreach (DataRow row in dt.Rows)
                        {
                            registros.Add(new InfoDivida(row.Field<string>("tipoRegistro"), row.Field<string>("filial"), row.Field<string>("modeloDocFiscal"), row.Field<string>("numeroDuplicata"), row.Field<string>("numeroParcela"), row.Field<string>("codigoCliente"), row.Field<string>("controleCgc"), row.Field<string>("dtVencimento"), row.Field<Single>("saldoTitulo"), row.Field<string>("numPedidoAndroid"), row.Field<string>("situacao")));
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