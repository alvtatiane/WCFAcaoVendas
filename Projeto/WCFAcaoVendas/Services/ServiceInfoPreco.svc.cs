﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCFAcaoVendas.DAL;

namespace WCFAcaoVendas.Services
{
    public class ServiceInfoPreco : IServiceInfoPreco
    {
        public InfoPreco[] Importar(string codigo)
        {
            try
            {
                return PrecoDAL.BuscarDados(codigo);
            }
            catch
            {
                return null;
            }
        }
    }
}
