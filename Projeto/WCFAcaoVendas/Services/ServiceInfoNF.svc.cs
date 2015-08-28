using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCFAcaoVendas.DAL;

namespace WCFAcaoVendas.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ServiceInfoNF" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ServiceInfoNF.svc or ServiceInfoNF.svc.cs at the Solution Explorer and start debugging.
    public class ServiceInfoNF : IServiceInfoNF
    {
        public InfoNF[] Importar(string codigo)
        {
            try
            {
                return NotaFiscalDAL.BuscarDados(codigo);
            }
            catch
            {
                return null;
            }
        }
    }
}
