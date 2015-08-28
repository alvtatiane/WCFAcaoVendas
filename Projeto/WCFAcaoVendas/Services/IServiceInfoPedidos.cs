﻿using System;
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
        public InfoPedido(InfoPrincipal infoPrincipal, InfoCondicaoPagamento[] infoCondicoesPagamento, InfoItem[] infoItens)
        {
            InfoPrincipal = infoPrincipal;
            InfoCondicoesPagamento = infoCondicoesPagamento;
            InfoItens = infoItens;
        }

        [DataMember]
        public InfoPrincipal InfoPrincipal;

        [DataMember]
        public InfoCondicaoPagamento[] InfoCondicoesPagamento;

        [DataMember]
        public InfoItem[] InfoItens;
    }

    #endregion

    #region InfoPrincipal
    [DataContract]
    public class InfoPrincipal
    {
        public InfoPrincipal(string tipoRegistro, string numPedidoAndroid, string codigoCliente, string controleCgc, string cpfCgc, string dtPedido, string dtEntrega, string frete, string codigoVendedor, string numPedidoCliente, string operacao, string entregaImadiata, string  prazo, string tabelaPreco, string percDesconto, string observacao, string codigoMensagem, string codigoFilial, string situacao)
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
        public string PercDesconto { get; set; }

        [DataMember]
        public string Observacao { get; set; }

        [DataMember]
        public string CodigoMensagem { get; set; }

        [DataMember]
        public string CodigoFilial { get; set; }

        [DataMember]
        public string Situacao { get; set; }
    }
    #endregion

    #region InfoCondicaoPagamento
    [DataContract]
    public class InfoCondicaoPagamento
    {
        public InfoCondicaoPagamento(string tipoRegistro, string numPedidoAndroid, string prazoDiasParcela, string dtVencimentoParcela, string valorParcela, string formaPagamento, string situacao)
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
        public string ValorParcela { get; set; }

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
        public InfoItem(string tipoRegistro, string numPedidoAndroid, string codigoProduto, string quantidade, string valorUnitario, string percComissao, string valorUnitarioTabelaPreco, string situacao)
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
        public string Quantidade { get; set; }

        [DataMember]
        public string ValorUnitario { get; set; }

        [DataMember]
        public string PercComissao { get; set; }

        [DataMember]
        public string ValorUnitarioTabelaPreco { get; set; }

        [DataMember]
        public string Situacao { get; set; }
    }
    #endregion
}
