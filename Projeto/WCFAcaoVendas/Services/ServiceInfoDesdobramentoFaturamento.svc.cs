using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCFAcaoVendas.DAL;

namespace WCFAcaoVendas.Services
{
    public class ServiceInfoDesdobramentoFaturamento : IServiceInfoDesdobramentoFaturamento
    {
        public InfoDesdobramentoFaturamento[] Importar(string codigo)
        {
            try
            {
                return DesdobramentoFaturamentoDAL.BuscarDados(codigo);
            }
            catch
            {
                return null;
            }
        }
    }
}
