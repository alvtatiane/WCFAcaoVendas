using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Transactions;
using WCFAcaoVendas.DAL;

namespace WCFAcaoVendas.Services
{
    public class ServiceLoginVendedor : IServiceLoginVendedor
    {
        public InfoLoginVendedor Importa(string codigo)
        {
            try
            {
                return LoginDAL.BuscarDados(codigo);
            }
            catch
            {
                return null;
            }
        }

        public void Exporta(InfoLoginVendedor infoLogin)
        {
            try
            {
                using (var scope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(0, 0, 55)))
                {
                    LoginDAL.Atualiza(infoLogin);
                    scope.Complete();
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
