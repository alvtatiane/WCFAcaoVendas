using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCFAcaoVendas.DAL;

namespace WCFAcaoVendas.Services
{
    public class ServiceInfoMensagem : IServiceInfoMensagem
    {
        public InfoMensagem[] Importar()
        {
            try
            {
                return MensagemDAL.BuscarDados();
            }
            catch
            {
                return null;
            }
        }
    }
}
