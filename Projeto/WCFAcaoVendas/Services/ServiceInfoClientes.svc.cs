using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCFAcaoVendas.DAL;
using System.Transactions;

namespace WCFAcaoVendas.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ServiceInfoClientes" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ServiceInfoClientes.svc or ServiceInfoClientes.svc.cs at the Solution Explorer and start debugging.
    public class ServiceInfoClientes : IServiceInfoClientes
    {
        public void Exportar(InfoClientes[] clientes)
        {
            try
            {            
                using (var scope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(0, 0, 55)))
                {
                    ClienteDAL.Atualiza(clientes);
                    scope.Complete();
                }
            }
            catch (Exception exception)
            {
                LogErro.Registrar(exception.Message);
                throw;
            }
        }

        public InfoClientes[] Importar(string codigo)
        {
            try
            {
                return ClienteDAL.BuscarDados(codigo);
            }
            catch
            {
                return null;
            }
        }

    }
}
