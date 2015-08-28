using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCFAcaoVendas.DAL;

namespace WCFAcaoVendas.Services
{
    public class ServiceInfoDividas : IServiceInfoDividas
    {
        public InfoDivida[] Importar(string codigo)
        {
            try
            {
                return DividasDAL.BuscarDados(codigo);
            }
            catch
            {
                return null;
            }
        }
    }
}
