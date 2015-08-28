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
    public abstract class ProdutoDAL
    {
        public static InfoProduto[] BuscarDados(string codigo)
        {
            try
            {
                using (SqlConnection conexao = FabricaSql.NovaConexao())
                {
                    using (SqlCommand comando = FabricaSql.NovoComandoTexto(conexao))
                    {
                        var query = new StringBuilder();
                        query.AppendLine("select    p.tipoRegistro, p.codigoVendedor, p.codigoProduto, p.nomeProduto, p.unidadeProduto, p.percComissao, p.situacao ");
                        query.AppendLine("from      Produto p ");
                        query.AppendLine("where     p.codigoVendedor = @codigo ");
                        query.AppendLine("          and (p.situacao <> 0) and p.tipoRegistro = '05'; ");

                        comando.CommandText = query.ToString();
                        comando.Parameters.Add("@codigo", SqlDbType.VarChar).Value = codigo;

                        DataTable dt = FabricaSql.GeraDataTable(comando);

                        List<InfoProduto> registros = new List<InfoProduto>();
                        foreach (DataRow row in dt.Rows)
                        {
                            registros.Add(new InfoProduto(row.Field<string>("tipoRegistro"), row.Field<string>("codigoVendedor"), row.Field<string>("codigoProduto"), row.Field<string>("nomeProduto"), row.Field<string>("unidadeProduto"), row.Field<Single>("percComissao"), row.Field<string>("situacao")));
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