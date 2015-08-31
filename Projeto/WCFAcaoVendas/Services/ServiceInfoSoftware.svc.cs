using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCFAcaoVendas.DAL;

namespace WCFAcaoVendas.Services
{
    public class ServiceInfoSoftware : IServiceInfoSoftware
    {
        public string Importa(string numeroVersao)
        {
            try
            {
                return SoftwareDAL.BuscarDados(numeroVersao);
            }
            catch
            {
                return null;
            }
        }
    }
}
