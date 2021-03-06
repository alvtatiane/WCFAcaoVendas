﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCFAcaoVendas.DAL;
using System.Transactions;

namespace WCFAcaoVendas.Services
{
    public class ServiceInfoClientes : IServiceInfoClientes
    {
        public InfoCliente[] Importar(string codigo)
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

        public void Exportar(InfoCliente[] clientes)
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

    }
}
