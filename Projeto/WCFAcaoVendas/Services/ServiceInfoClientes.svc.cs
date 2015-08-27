using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCFAcaoVendas.DAL;

namespace WCFAcaoVendas.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ServiceInfoClientes" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ServiceInfoClientes.svc or ServiceInfoClientes.svc.cs at the Solution Explorer and start debugging.
    public class ServiceInfoClientes : IServiceInfoClientes
    {
        public void Exportar(InfoClientes[] clientes)
        {
            foreach (var cliente in clientes)
            {
                if (cliente.Situacao == "1")    //Novo cliente
                {
                    ClienteDAL.InserirDados(cliente);
                }
                else if (cliente.Situacao == "2") //Cliente alterado
                {
                    ClienteDAL.AlterarDados(cliente);
                }
                else 
                {
                    LogErro.Registrar("Situação não encontrada.");
                }
            }
            
        }

        public InfoClientes[] Importar(string codigo)
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

    }
}
