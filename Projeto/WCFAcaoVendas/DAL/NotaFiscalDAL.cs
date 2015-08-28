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
    public abstract class NotaFiscalDAL
    {
        public static InfoNF[] BuscarDados(string codigo)
        {
            try
            {
                using (SqlConnection conexao = FabricaSql.NovaConexao())
                {
                    using (SqlCommand comando = FabricaSql.NovoComandoTexto(conexao))
                    {
                        var query = new StringBuilder();
                        query.AppendLine("select    nf.tipoRegistro, nf.codigoVendedor, nf.filial, nf.modeloDocFiscal, nf.numeroNF, nf.codigoCliente, nf.controleCgc, nf.numPedidoInterno, nf.codigoProduto, nf.numPedidoAndroid, nf.dtPedido, nf.quantidadePedido, nf.quantidadeAtendida, nf.quantidadeProdutoItem, nf.valorTotalProdutoItem, nf.dtEmissao, nf.situacao ");
                        query.AppendLine("from      NotaFiscal nf ");
                        query.AppendLine("where     nf.codigoVendedor = @codigo ");
                        query.AppendLine("          and (nf.situacao <> 0) and nf.tipoRegistro = '04'; ");

                        comando.CommandText = query.ToString();
                        comando.Parameters.Add("@codigo", SqlDbType.VarChar).Value = codigo;

                        DataTable dt = FabricaSql.GeraDataTable(comando);

                        List<InfoNF> registros = new List<InfoNF>();
                        foreach (DataRow row in dt.Rows)
                        {
                            registros.Add(new InfoNF(row.Field<string>("tipoRegistro"), row.Field<string>("codigoVendedor"), row.Field<string>("filial"), row.Field<string>("modeloDocFiscal"), row.Field<string>("numeroNF"), row.Field<string>("codigoCliente"), row.Field<string>("controleCgc"), row.Field<string>("numPedidoInterno"), row.Field<string>("codigoProduto"), row.Field<string>("numPedidoAndroid"), row.Field<string>("dtPedido"), row.Field<Single>("quantidadePedido"), row.Field<Single>("quantidadeAtendida"), row.Field<Single>("quantidadeProdutoItem"), row.Field<Single>("valorTotalProdutoItem"), row.Field<string>("dtEmissao"), row.Field<string>("situacao")));
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