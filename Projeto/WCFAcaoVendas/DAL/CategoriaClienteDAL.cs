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
    public abstract class CategoriaClienteDAL
    {
        public static CategoriaCliente[] BuscarDados()
        {
            try
            {
                using (SqlConnection conexao = FabricaSql.NovaConexao())
                {
                    using (SqlCommand comando = FabricaSql.NovoComandoTexto(conexao))
                    {
                        var query = new StringBuilder();
                        query.AppendLine("select    cc.tipoRegistro, cc.codigoCategoria, cc.nomeCategoria, cc.situacao ");
                        query.AppendLine("from      CategoriaCliente cc ");
                        query.AppendLine("where     cc.situacao <> 0; ");

                        comando.CommandText = query.ToString();

                        DataTable dt = FabricaSql.GeraDataTable(comando);

                        List<CategoriaCliente> registros = new List<CategoriaCliente>();
                        foreach (DataRow row in dt.Rows)
                        {
                            registros.Add(new CategoriaCliente(row.Field<string>("tipoRegistro"), row.Field<string>("codigoCategoria"), row.Field<string>("nomeCategoria"), row.Field<string>("situacao")));
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