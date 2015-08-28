using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCFAcaoVendas.DAL;

namespace WCFAcaoVendas.Services
{
    public class ServiceInfoProduto : IServiceInfoProduto
    {
        public InfoProduto[] Importar(string codigo)
        {
            try
            {
                return ProdutoDAL.BuscarDados(codigo);
            }
            catch
            {
                return null;
            }
        }
    }
}
