using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Transactions;
using WCFAcaoVendas.DAL;
using ManipulaTxt;

namespace WCFAcaoVendas.Services
{
    public class ServiceInfoPedidos : IServiceInfoPedidos
    {
        public InfoPedido[] Importar(string codigo)
        {
            try
            {
                return PedidoDAL.BuscarDados(codigo);
            }
            catch
            {
                return null;
            }
        }

        public void Exportar(InfoPedido[] pedidos)
        {
            Email[] emails = null;

            try
            {
                using (var scope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(0, 0, 55)))
                {
                    emails = PedidoDAL.Atualiza(pedidos);   
                    scope.Complete();
                }
            }
            catch (Exception exception)
            {
                DAL.LogErro.Registrar(exception.Message);
                //throw;
            }

            if (emails != null)
            {
                foreach (var email in emails)
                {
                    EmailDAL.Enviar(email);
                }
            }

            Atualizacao a = new Atualizacao();
            //a.Executa();
        }

        
    }
}
