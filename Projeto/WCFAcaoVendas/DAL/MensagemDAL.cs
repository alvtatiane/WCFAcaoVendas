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
    public abstract class MensagemDAL
    {
        public static InfoMensagem[] BuscarDados()
        {
            try
            {
                using (SqlConnection conexao = FabricaSql.NovaConexao())
                {
                    using (SqlCommand comando = FabricaSql.NovoComandoTexto(conexao))
                    {
                        var query = new StringBuilder();
                        query.AppendLine("select    m.tipoRegistro, m.codigoMensagem, m.referencia, coalesce(m.linhaMsg1, '') + ' ' + coalesce(m.linhaMsg2, '') + ' ' + coalesce(m.linhaMsg3, '') + ' ' + coalesce(m.linhaMsg4, '') as conteudo, m.situacao");
                        query.AppendLine("from      Mensagens m ");
                        query.AppendLine("where     (m.situacao <> 0) and m.tipoRegistro = '08'; ");

                        comando.CommandText = query.ToString();

                        DataTable dt = FabricaSql.GeraDataTable(comando);

                        List<InfoMensagem> registros = new List<InfoMensagem>();
                        foreach (DataRow row in dt.Rows)
                        {
                            registros.Add(new InfoMensagem(row.Field<string>("tipoRegistro"), row.Field<string>("codigoMensagem"), row.Field<string>("referencia"), row.Field<string>("conteudo"), row.Field<string>("situacao")));
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