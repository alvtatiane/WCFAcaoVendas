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
    public abstract class PedidoDAL
    {
        public static void Atualiza(InfoPedido[] pedidos)
        {
            try
            {
                using (SqlConnection conexao = FabricaSql.NovaConexao())
                {
                    using (SqlCommand comando = FabricaSql.NovoComandoTexto(conexao))
                    {

                        foreach (var pedido in pedidos)
                        {
                            if (pedido.Situacao == "1")    //Novo pedido
                            {
                                InserirDados(comando, pedido);
                            }
                            else if (pedido.Situacao == "2") //Pedido alterado
                            {
                                //VerificaSePedidoAindaNaoImportado();
                                //AlterarDados(comando, cliente);
                            }
                            else
                            {
                                throw new Exception("Campo situação não encontrado.");
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                LogErro.Registrar(exception.Message);
                throw;
            }

        }

        private static void InserirDados(SqlCommand comando, InfoPedido infoPedido)
        {
            var query = new StringBuilder();
            query.AppendLine("");

            comando.Parameters.Add("@situacao", SqlDbType.VarChar).Value = infoPedido.Situacao;

            comando.CommandText = query.ToString();
            comando.ExecuteNonQuery();
        }
    }
}