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
    public abstract class PrecoDAL
    {
        public static InfoPreco[] BuscarDados(string codigo)
        {
            try
            {
                using (SqlConnection conexao = FabricaSql.NovaConexao())
                {
                    using (SqlCommand comando = FabricaSql.NovoComandoTexto(conexao))
                    {
                        var query = new StringBuilder();
                        query.AppendLine("select    p.tipoRegistro, p.numTabelaPreco, p.codigoProduto, p.valorAVistaProduto , p.situacao ");
                        query.AppendLine("from      Produto po ");
                        query.AppendLine("          left join Preco p ");
                        query.AppendLine("          on p.codigoProduto = po.codigoProduto ");
                        query.AppendLine("where     po.codigoVendedor = @codigo ");
                        query.AppendLine("          and (p.situacao <> 0) and p.tipoRegistro = '06'; ");

                        comando.CommandText = query.ToString();
                        comando.Parameters.Add("@codigo", SqlDbType.VarChar).Value = codigo;

                        DataTable dt = FabricaSql.GeraDataTable(comando);

                        List<InfoPreco> registros = new List<InfoPreco>();
                        foreach (DataRow row in dt.Rows)
                        {
                            registros.Add(new InfoPreco(row.Field<string>("tipoRegistro"), row.Field<string>("numTabelaPreco"), row.Field<string>("codigoProduto"), row.Field<Single>("valorAVistaProduto"), row.Field<string>("situacao")));
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