﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Transactions;
using WCFAcaoVendas.DAL;

namespace WCFAcaoVendas.Services
{
    public class ServiceInfoPedidos : IServiceInfoPedidos
    {
        public InfoPedido[] Importar(string codigo)
        {
            try
            {
                return PedidoDAL.BuscarDados(codigo);
            }
            catch
            {
                return null;
            }
        }

        public void Exportar(InfoPedido[] pedidos)
        {
            try
            {
                using (var scope = new TransactionScope(TransactionScopeOption.Required, new TimeSpan(0, 0, 55)))
                {
                    Email[] email = PedidoDAL.Atualiza(pedidos);
                    EmailDAL.Enviar(email);
                    scope.Complete();
                }
            }
            catch (Exception exception)
            {
                LogErro.Registrar(exception.Message);
                //throw;
            }
        }

        
    }
}
