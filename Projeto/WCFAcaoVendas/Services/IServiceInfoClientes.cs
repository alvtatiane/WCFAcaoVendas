using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFAcaoVendas.Services
{
    [ServiceContract]
    public interface IServiceInfoClientes
    {
        [OperationContract]
        InfoCliente[] Importar(string codigo);

        [OperationContract]
        void Exportar(InfoCliente[] clientes);
    }

    #region InfoCliente
    [DataContract]
    public class InfoCliente
    {
        public InfoCliente(string tipoRegistro, string codigoVendedor, string codigoCliente, string controleCgc, string nomeCliente, string nomeFantasia, string endereco, string numeroEndereco, string complemento, string bairro, string cidade, string estado, string cep, string digitoCep, string telComercial, string telFax, string regiaoVendas, string nomeReV, string rotaVisita, string nomeRoV, string codMunicipio, string codEstado, string codPais, string codAtividadeCliente, string codCategoriaCliente, string codRegiaoSeguro, string codGrupoCliente, Single limiteCredito, string formaPagam, string nomeContatoComercial, string cpfCgc, string email, Single percAcrescimo, string inscricaoEstadual, string tipoBloqueio, string descricaoBloqueio, string tipoDocumento, string situacao)
        {
            TipoRegistro = tipoRegistro;
            CodigoVendedor = codigoVendedor;
            CodigoCliente = codigoCliente;
            ControleCgc = controleCgc;
            NomeCliente = nomeCliente;
            NomeFantasia = nomeFantasia;
            Endereco = endereco;
            NumeroEndereco = numeroEndereco;
            Complemento = complemento;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
            CEP = cep;
            DigitoCEP = digitoCep;
            TelComercial = telComercial;
            TelFax = telFax;
            RegiaoVendas = regiaoVendas;
            NomeRegiaoVendas = nomeReV;
            RotaVisita = rotaVisita;
            NomeRotaVisita = nomeRoV;
            CodigoMunicipio = codMunicipio;
            CodigoEstado = codEstado;
            CodigoPais = codPais;
            CodigoAtividadeCliente = codAtividadeCliente;
            CodigoCategoriaCliente = codCategoriaCliente;
            CodigoRegiaoSeguro = codRegiaoSeguro;
            CodigoGrupoCliente = codGrupoCliente;
            LimiteCredito = limiteCredito;
            FormaPagamento = formaPagam;
            NomeContatoComercial = nomeContatoComercial;
            CpfCgc = cpfCgc;
            Email = email;
            PercAcrescimo = percAcrescimo;
            InscricaoEstadual = inscricaoEstadual;
            TipoBloqueio = tipoBloqueio;
            DescricaoBloqueio = descricaoBloqueio;
            TipoDocumento = tipoDocumento;
            Situacao = situacao;    //Situacao  = 1 -> novo cliente
                                    //          = 2 -> cliente alterado
                                    //          = 3 -> cliente deletado
        }

        [DataMember]
        public string TipoRegistro { get; set; } /*Tem valor = 01*/

        [DataMember]
        public string CodigoVendedor { get; set; }

        [DataMember]
        public string CodigoCliente { get; set; }

        [DataMember]
        public string ControleCgc { get; set; }

        [DataMember]
        public string NomeCliente { get; set; }

        [DataMember]
        public string NomeFantasia { get; set; }

        [DataMember]
        public string Endereco { get; set; }

        [DataMember]
        public string NumeroEndereco { get; set; }

        [DataMember]
        public string Complemento { get; set; }

        [DataMember]
        public string Bairro { get; set; }

        [DataMember]
        public string Cidade { get; set; }

        [DataMember]
        public string Estado { get; set; }

        [DataMember]
        public string CEP { get; set; }

        [DataMember]
        public string DigitoCEP { get; set; }

        [DataMember]
        public string TelComercial { get; set; }

        [DataMember]
        public string TelFax { get; set; }

        [DataMember]
        public string RegiaoVendas { get; set; }

        [DataMember]
        public string NomeRegiaoVendas { get; set; }

        [DataMember]
        public string RotaVisita { get; set; }

        [DataMember]
        public string NomeRotaVisita { get; set; }

        [DataMember]
        public string CodigoMunicipio { get; set; }

        [DataMember]
        public string CodigoEstado { get; set; }

        [DataMember]
        public string CodigoPais { get; set; }

        [DataMember]
        public string CodigoAtividadeCliente { get; set; }

        [DataMember]
        public string CodigoCategoriaCliente { get; set; }

        [DataMember]
        public string CodigoRegiaoSeguro { get; set; }

        [DataMember]
        public string CodigoGrupoCliente { get; set; }

        [DataMember]
        public Single LimiteCredito { get; set; }

        [DataMember]
        public string FormaPagamento { get; set; }

        [DataMember]
        public string NomeContatoComercial { get; set; }

        [DataMember]
        public string CpfCgc { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public Single PercAcrescimo { get; set; }

        [DataMember]
        public string InscricaoEstadual { get; set; }

        [DataMember]
        public string TipoBloqueio { get; set; }

        [DataMember]
        public string DescricaoBloqueio { get; set; }

        [DataMember]
        public string TipoDocumento { get; set; }

        [DataMember]
        public string Situacao { get; set; }
  

    }
    #endregion
}
