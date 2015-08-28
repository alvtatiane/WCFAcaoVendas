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
    public abstract class FormaPagamentoDAL
    {
        public static InfoFormaPagamento[] BuscarDados(string codigo)
        {
            try
            {
                using (SqlConnection conexao = FabricaSql.NovaConexao())
                {
                    using (SqlCommand comando = FabricaSql.NovoComandoTexto(conexao))
                    {
                        var query = new StringBuilder();
                        query.AppendLine("select    c.tipoRegistro, c.codigoVendedor, c.numTabelaPreco, c.prazoTabelaPreco, c.identificacaoTabela, c.percJurosTabelaPreco, c.percDescontoTabelaPreco, c.situacao ");
                        query.AppendLine("from      CondicoesPagamento c ");
                        query.AppendLine("where     c.codigoVendedor = @codigo ");
                        query.AppendLine("          and (c.situacao <> 0) and c.tipoRegistro = '02'; ");

                        comando.CommandText = query.ToString();
                        comando.Parameters.Add("@codigo", SqlDbType.VarChar).Value = codigo;

                        DataTable dt = FabricaSql.GeraDataTable(comando);

                        List<InfoFormaPagamento> registros = new List<InfoFormaPagamento>();
                        foreach (DataRow row in dt.Rows)
                        {
                            registros.Add(new InfoFormaPagamento(row.Field<string>("tipoRegistro"), row.Field<string>("codigoVendedor"), row.Field<string>("numTabelaPreco"), row.Field<string>("prazoTabelaPreco"), row.Field<string>("identificacaoTabela"), row.Field<Single>("percJurosTabelaPreco"), row.Field<Single>("percDescontoTabelaPreco"), row.Field<string>("situacao")));
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