using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFAcaoVendas.Services
{
    [ServiceContract]
    public interface IServiceInfoPedidos
    {
        [OperationContract]
        InfoPedido[] Importar(string codigo);

        [OperationContract]
        void Exportar(InfoPedido[] pedidos);
    }

    #region InfoPedido
    [DataContract]
    public class InfoPedido
    {
        public InfoPedido(InfoPrincipal infoPrincipal, InfoCondicaoPagamento[] infoCondicoesPagamento, InfoItem[] infoItens, string situacao)
        {
            InfoPrincipal = infoPrincipal;
            InfoCondicoesPagamento = infoCondicoesPagamento;
            InfoItens = infoItens;
            Situacao = situacao;
        }

        [DataMember]
        public InfoPrincipal InfoPrincipal;

        [DataMember]
        public InfoCondicaoPagamento[] InfoCondicoesPagamento;

        [DataMember]
        public InfoItem[] InfoItens;

        [DataMember]
        public string Situacao { get; set; }
    }

    #endregion

    #region InfoPrincipal
    [DataContract]
    public class InfoPrincipal
    {
        public InfoPrincipal(string tipoRegistro, string numPedidoAndroid, string codigoCliente, string controleCgc, string cpfCgc, string dtPedido, string dtEntrega, string frete, string codigoVendedor, string numPedidoCliente, string operacao, string entregaImadiata, string  prazo, string tabelaPreco, Single percDesconto, string observacao, string codigoMensagem, string codigoFilial, string dtEnvio, string situacao)
        {
            TipoRegistro = tipoRegistro;
            NumPedidoAndroid = numPedidoAndroid;
            CodigoCliente = codigoCliente;
            ControleCgc = controleCgc;
            CpfCgc = cpfCgc;
            DtPedido = dtPedido;
            DtEntrega = dtEntrega;
            Frete = frete;
            CodigoVendedor = codigoVendedor;
            NumPedidoCliente = numPedidoCliente;
            Operacao = operacao;
            EntregaImediata = entregaImadiata;
            Prazo = prazo;
            TabelaPreco = tabelaPreco;
            PercDesconto = percDesconto;
            Observacao = observacao;
            CodigoMensagem = codigoMensagem;
            CodigoFilial = codigoFilial;
            DtEnvio = dtEnvio;
            Situacao = situacao;
        }

        [DataMember]
        public string TipoRegistro { get; set; }

        [DataMember]
        public string NumPedidoAndroid { get; set; }

        [DataMember]
        public string CodigoCliente { get; set; }

        [DataMember]
        public string ControleCgc { get; set; }

        [DataMember]
        public string CpfCgc { get; set; }

        [DataMember]
        public string DtPedido { get; set; }

        [DataMember]
        public string DtEntrega { get; set; }

        [DataMember]
        public string Frete { get; set; }

        [DataMember]
        public string CodigoVendedor { get; set; }

        [DataMember]
        public string NumPedidoCliente { get; set; }

        [DataMember]
        public string Operacao { get; set; }

        [DataMember]
        public string EntregaImediata { get; set; }

        [DataMember]
        public string Prazo { get; set; }

        [DataMember]
        public string TabelaPreco { get; set; }

        [DataMember]
        public Single PercDesconto { get; set; }

        [DataMember]
        public string Observacao { get; set; }

        [DataMember]
        public string CodigoMensagem { get; set; }

        [DataMember]
        public string CodigoFilial { get; set; }

        [DataMember]
        public string DtEnvio { get; set; }

        [DataMember]
        public string Situacao { get; set; }
    }
    #endregion

    #region InfoCondicaoPagamento
    [DataContract]
    public class InfoCondicaoPagamento
    {
        public InfoCondicaoPagamento(string tipoRegistro, string numPedidoAndroid, string prazoDiasParcela, string dtVencimentoParcela, Single valorParcela, string formaPagamento, string situacao)
        {
            TipoRegistro = tipoRegistro;
            NumPedidoAndroid = numPedidoAndroid;
            PrazoDiasParcela = prazoDiasParcela;
            DtVencimentoParcela = dtVencimentoParcela;
            ValorParcela = valorParcela;
            FormaPagamento = formaPagamento;
            Situacao = situacao;
        }

        [DataMember]
        public string TipoRegistro { get; set; }

        [DataMember]
        public string NumPedidoAndroid { get; set; }

        [DataMember]
        public string PrazoDiasParcela { get; set; }

        [DataMember]
        public string DtVencimentoParcela { get; set; }

        [DataMember]
        public Single ValorParcela { get; set; }

        [DataMember]
        public string FormaPagamento { get; set; }

        [DataMember]
        public string Situacao { get; set; }
    }
    #endregion

    #region InfoItem
    [DataContract]
    public class InfoItem
    {
        public InfoItem(string tipoRegistro, string numPedidoAndroid, string codigoProduto, Single quantidade, Single valorUnitario, Single percComissao, Single valorUnitarioTabelaPreco, string situacao)
        {
            TipoRegistro = tipoRegistro;
            NumPedidoAndroid = numPedidoAndroid;
            CodigoProduto = codigoProduto;
            Quantidade = quantidade;
            ValorUnitario = valorUnitario;
            PercComissao = percComissao;
            ValorUnitarioTabelaPreco = valorUnitarioTabelaPreco;
            Situacao = situacao;
        }

        [DataMember]
        public string TipoRegistro { get; set; }

        [DataMember]
        public string NumPedidoAndroid { get; set; }

        [DataMember]
        public string CodigoProduto { get; set; }

        [DataMember]
        public Single Quantidade { get; set; }

        [DataMember]
        public Single ValorUnitario { get; set; }

        [DataMember]
        public Single PercComissao { get; set; }

        [DataMember]
        public Single ValorUnitarioTabelaPreco { get; set; }

        [DataMember]
        public string Situacao { get; set; }
    }
    #endregion

    #region Email
    [DataContract]
    public class Email
    {
        public Email(string assunto, string mensagem, string destinatario)
        {
            Assunto = assunto;
            Mensagem = mensagem;
            Destinatario = destinatario;
            
        }

        [DataMember]
        public string Destinatario { get; set; }

        [DataMember]
        public string Assunto { get; set; }

        [DataMember]
        public string Mensagem { get; set; }
        
    }

    #endregion

}
