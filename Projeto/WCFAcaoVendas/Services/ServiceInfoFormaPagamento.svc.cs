using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCFAcaoVendas.DAL;

namespace WCFAcaoVendas.Services
{
    public class ServiceInfoFormaPagamento : IServiceInfoFormaPagamento
    {
        public InfoFormaPagamento[] Importar(string codigo)
        {
            try
            {
                return FormaPagamentoDAL.BuscarDados(codigo);
            }
            catch
            {
                return null;
            }
        }
    }
}
