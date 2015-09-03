using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFAcaoVendas.Services
{
    [ServiceContract]
    public interface IServiceInfoGerais
    {
        [OperationContract]
        Municipio[] ImportaMunicipio();

        [OperationContract]
        Estado[] ImportaEstado();

        [OperationContract]
        Pais[] ImportaPais();

        [OperationContract]
        Atividade[] ImportaAtividade();

        [OperationContract]
        RegiaoVenda[] ImportaRegiaoVenda();

        [OperationContract]
        RotaVisita[] ImportaRotaVisita();

        [OperationContract]
        CategoriaCliente[] ImportaCategoriaCliente();

        [OperationContract]
        GrupoCliente[] ImportaGrupoCliente();

        [OperationContract]
        RegiaoSeguro[] ImportaRegiaoSeguro();
    }

    #region RegiaoVenda
    [DataContract]
    public class RegiaoVenda
    {
        public RegiaoVenda(string tipoRegistro, string codigoRegiao, string nomeRegiao, string cidadeRegiao, string estadoRegiao, string situacao)
        {
            TipoRegistro = tipoRegistro;
            CodigoRegiao = codigoRegiao;
            NomeRegiao = nomeRegiao;
            CidadeRegiao = cidadeRegiao;
            EstadoRegiao = estadoRegiao;
            Situacao = situacao;
        }

        [DataMember]
        public string TipoRegistro { get; set; }

        [DataMember]
        public string CodigoRegiao { get; set; }

        [DataMember]
        public string NomeRegiao { get; set; }

        [DataMember]
        public string CidadeRegiao { get; set; }

        [DataMember]
        public string EstadoRegiao { get; set; }

        [DataMember]
        public string Situacao { get; set; }
    }
    #endregion

    #region RotaVisita
    [DataContract]
    public class RotaVisita
    {
        public RotaVisita(string tipoRegistro, string codigoRota, string nomeRota, string cidadeRota, string estadoRota, string situacao)
        {
            TipoRegistro = tipoRegistro;
            CodigoRota = codigoRota;
            NomeRota = nomeRota;
            CidadeRota = cidadeRota;
            EstadoRota = estadoRota;
            Situacao = situacao;
        }

        [DataMember]
        public string TipoRegistro { get; set; }

        [DataMember]
        public string CodigoRota { get; set; }

        [DataMember]
        public string NomeRota { get; set; }

        [DataMember]
        public string CidadeRota { get; set; }

        [DataMember]
        public string EstadoRota { get; set; }

        [DataMember]
        public string Situacao { get; set; }
    }
    #endregion

    #region Municipio
    [DataContract]
    public class Municipio
    {
        public Municipio(string tipoRegistro, string codigoMunicipio, string nomeMunicipio, string uf, string situacao)
        {
            TipoRegistro = tipoRegistro;
            CodigoMunicipio = codigoMunicipio;
            NomeMunicipio = nomeMunicipio;
            Uf = uf;
            Situacao = situacao;
        }

        [DataMember]
        public string TipoRegistro { get; set; }

        [DataMember]
        public string CodigoMunicipio { get; set; }

        [DataMember]
        public string NomeMunicipio { get; set; }

        [DataMember]
        public string Uf { get; set; } //Estado onde o municipio se encontra

        [DataMember]
        public string Situacao { get; set; }
    }
    #endregion

    #region Estado
    [DataContract]
    public class Estado
    {
        public Estado(string tipoRegistro, string codigoEstado, string nomeEstado, string uf, string situacao)
        {
            TipoRegistro = tipoRegistro;
            CodigoEstado = codigoEstado;
            NomeEstado = nomeEstado;
            Uf = uf;
            Situacao = situacao;
        }

        [DataMember]
        public string TipoRegistro { get; set; }

        [DataMember]
        public string CodigoEstado { get; set; }

        [DataMember]
        public string NomeEstado { get; set; }

        [DataMember]
        public string Uf { get; set; }

        [DataMember]
        public string Situacao { get; set; }
    }
    #endregion

    #region Pais
    [DataContract]
    public class Pais
    {
        public Pais(string tipoRegistro, string codigoPais, string nomePais, string situacao)
        {
            TipoRegistro = tipoRegistro;
            CodigoPais = codigoPais;
            NomePais = nomePais;
            Situacao = situacao;
        }

        [DataMember]
        public string TipoRegistro { get; set; }

        [DataMember]
        public string CodigoPais { get; set; }

        [DataMember]
        public string NomePais { get; set; }

        [DataMember]
        public string Situacao { get; set; }
    }
    #endregion

    #region Atividade
    [DataContract]
    public class Atividade
    {
        public Atividade(string tipoRegistro, string codigoAtividade, string nomeAtividade, string situacao)
        {
            TipoRegistro = tipoRegistro;
            CodigoAtividade = codigoAtividade;
            NomeAtividade = nomeAtividade;
            Situacao = situacao;
        }

        [DataMember]
        public string TipoRegistro { get; set; }

        [DataMember]
        public string CodigoAtividade { get; set; }

        [DataMember]
        public string NomeAtividade { get; set; }

        [DataMember]
        public string Situacao { get; set; }
    }
    #endregion

    #region CategoriaCliente
    [DataContract]
    public class CategoriaCliente
    {
        public CategoriaCliente(string tipoRegistro, string codigoCategoria, string nomeCategoria, string situacao)
        {
            TipoRegistro = tipoRegistro;
            CodigoCategoria = codigoCategoria;
            NomeCategoria = nomeCategoria;
            Situacao = situacao;
        }

        [DataMember]
        public string TipoRegistro { get; set; }

        [DataMember]
        public string CodigoCategoria { get; set; }

        [DataMember]
        public string NomeCategoria { get; set; }

        [DataMember]
        public string Situacao { get; set; }
    }
    #endregion

    #region GrupoCliente
    [DataContract]
    public class GrupoCliente
    {
        public GrupoCliente(string tipoRegistro, string codigoGrupo, string nomeGrupo, string situacao)
        {
            TipoRegistro = tipoRegistro;
            CodigoGrupo = codigoGrupo;
            NomeGrupo = nomeGrupo;
            Situacao = situacao;
        }

        [DataMember]
        public string TipoRegistro { get; set; }

        [DataMember]
        public string CodigoGrupo { get; set; }

        [DataMember]
        public string NomeGrupo { get; set; }

        [DataMember]
        public string Situacao { get; set; }
    }
    #endregion

    #region RegiaoSeguro
    [DataContract]
    public class RegiaoSeguro
    {
        public RegiaoSeguro(string tipoRegistro, string codigoRegiaoSeguro, string nomeRegiaoSeguro, string estadoRegiaoSeguro, string situacao)
        {
            TipoRegistro = tipoRegistro;
            CodigoRegiaoSeguro = codigoRegiaoSeguro;
            NomeRegiaoSeguro = nomeRegiaoSeguro;
            EstadoRegiaoSeguro = estadoRegiaoSeguro;
            Situacao = situacao;
        }

        [DataMember]
        public string TipoRegistro { get; set; }

        [DataMember]
        public string CodigoRegiaoSeguro { get; set; }

        [DataMember]
        public string NomeRegiaoSeguro { get; set; }

        [DataMember]
        public string EstadoRegiaoSeguro { get; set; }

        [DataMember]
        public string Situacao { get; set; }
    }
    #endregion
}
