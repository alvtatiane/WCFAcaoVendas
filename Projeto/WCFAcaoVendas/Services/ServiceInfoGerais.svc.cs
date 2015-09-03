using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCFAcaoVendas.DAL;

namespace WCFAcaoVendas.Services
{
    public class ServiceInfoGerais : IServiceInfoGerais
    {
        public Municipio[] ImportaMunicipio()
        {
            try
            {
                return MunicipioDAL.BuscarDados();
            }
            catch
            {
                return null;
            }
        }

        public Estado[] ImportaEstado()
        {
            try
            {
                return EstadoDAL.BuscarDados();
            }
            catch
            {
                return null;
            }
        }

        public Pais[] ImportaPais()
        {
            try
            {
                return PaisDAL.BuscarDados();
            }
            catch
            {
                return null;
            }
        }

        public Atividade[] ImportaAtividade()
        {
            try
            {
                return AtividadeDAL.BuscarDados();
            }
            catch
            {
                return null;
            }
        }

        public CategoriaCliente[] ImportaCategoriaCliente()
        {
            try
            {
                return CategoriaClienteDAL.BuscarDados();
            }
            catch
            {
                return null;
            }
        }

        public GrupoCliente[] ImportaGrupoCliente()
        {
            try
            {
                return GrupoClienteDAL.BuscarDados();
            }
            catch
            {
                return null;
            }
        }

        public RegiaoSeguro[] ImportaRegiaoSeguro()
        {
            try
            {
                return RegiaoSeguroDAL.BuscarDados();
            }
            catch
            {
                return null;
            }
        }

        public RegiaoVenda[] ImportaRegiaoVenda()
        {
            try
            {
                return RegiaoVendaDAL.BuscarDados();
            }
            catch
            {
                return null;
            }
        }

        public RotaVisita[] ImportaRotaVisita()
        {
            try
            {
                return RotaVisitaDAL.BuscarDados();
            }
            catch
            {
                return null;
            }
        }
    }
}
