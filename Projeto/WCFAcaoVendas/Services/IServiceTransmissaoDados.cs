using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFAcaoVendas.Services
{
    [ServiceContract]
    public interface IServiceTransmissaoDados
    {
        [OperationContract]
        void DoWork();
    }

    #region InfoFormaPagamento
    [DataContract]
    public class InfoFormaPagamento
    {
        [DataMember]
        public string tipoRegistro; /*Tem valor = 02*/

        [DataMember]
        public string vendedor;

        [DataMember]
        public string numTabela;

        [DataMember]
        public string prazo;

        [DataMember]
        public string identificacao;

        [DataMember]
        public Single percJuros;

        [DataMember]
        public Single percDesconto;

        [DataMember]
        public int ativo;
    }
    #endregion

    #region InfoInadimplencia
    public class InfoInadimplencia
    {
        [DataMember]
        public string tipoRegistro; /*Tem valor = 03*/

        [DataMember]
        public string filial;

        [DataMember]
        public string modeloDocFiscal;

        [DataMember]
        public string numeroDuplicata;

        [DataMember]
        public string numeroParcela;

        [DataMember]
        public string codigoCliente;

        [DataMember]
        public string controleCgc;

        [DataMember]
        public string dtVencimento;

        [DataMember]
        public Single saldoTitulo;

        [DataMember]
        public string pedidoPalm;

        [DataMember]
        public int ativo;
    }
    #endregion

    #region InfoNF
    public class InfoNF
    {
        [DataMember]
        public string tipoRegistro; /*Tem valor = 04*/

        [DataMember]
        public string vendedor;

        [DataMember]
        public string filial;

        [DataMember]
        public string modeloDocFiscal;

        [DataMember]
        public string numNF;

        [DataMember]
        public string codigoCliente;

        [DataMember]
        public string controleCgc;

        [DataMember]
        public string numeroPedidoInterno;

        [DataMember]
        public string codigoProduto;

        [DataMember]
        public string pedidoPalm;

        [DataMember]
        public string dtPedido;

        [DataMember]
        public Single quantidadePedido;

        [DataMember]
        public Single quantidadeAtendida;

        [DataMember]
        public Single quantidadeProdutoItem;

        [DataMember]
        public Single valorTotalProdutoItem;

        [DataMember]
        public string dtEmissao;

        [DataMember]
        public int ativo;
    }
    #endregion

    #region InfoProdutos
    public class InfoProdutos
    {
        [DataMember]
        public string tipoRegistro; /*Tem valor = 05*/

        [DataMember]
        public string vendedor;

        [DataMember]
        public string codigoProduto;

        [DataMember]
        public string nomeProduto;

        [DataMember]
        public string unidadeProduto;

        [DataMember]
        public Single quantidadeUnidEmbalagem;

        [DataMember]
        public Single pesoLiquidoUnidade;

        [DataMember]
        public Single pesoEmbalagem;

        [DataMember]
        public Single percComissao;

        [DataMember]
        public string codigoBarraEan13;

        [DataMember]
        public int ativo;
    }
    #endregion

    #region InfoPrecos
    public class InfoPrecos
    {
        [DataMember]
        public string tipoRegistro; /*Tem valor = 06*/

        [DataMember]
        public string tabelaPreco;

        [DataMember]
        public string codigoProduto;

        [DataMember]
        public Single valorAVistaProduto;

        [DataMember]
        public int ativo;
    }
    #endregion

    #region InfoDesdobramentoFaturamento
    public class InfoDesdobramentoFaturamento
    {
        [DataMember]
        public string tipoRegistro; /*Tem valor = 07*/

        [DataMember]
        public string vendedor;

        [DataMember]
        public string codigoCliente;

        [DataMember]
        public string controleCgc;

        [DataMember]
        public string numeroPedidoInterno;

        [DataMember]
        public string pedidoPalm;

        [DataMember]
        public string dtPedido;

        [DataMember]
        public string filial;

        [DataMember]
        public string modeloDocFiscal;

        [DataMember]
        public string numeroDuplicata;

        [DataMember]
        public string numeroParcela;

        [DataMember]
        public Single valorParcela;

        [DataMember]
        public string dtVencimento;

        [DataMember]
        public int ativo;
    }
    #endregion

    #region InfoMensagens
    public class InfoMensagens
    {
        [DataMember]
        public string tipoRegistro; /*Tem valor = 08*/

        [DataMember]
        public string codigoMensagem;

        [DataMember]
        public string referencia;

        [DataMember]
        public string linhaMsg1;

        [DataMember]
        public string linhaMsg2;

        [DataMember]
        public string linhaMsg3;

        [DataMember]
        public string linhaMsg4;

        [DataMember]
        public int ativo;
    }
    #endregion

    /*Dados sobre o pedido*/
    #region DadosPrincipaisPedido
    public class DadosPrincipaisPedido
    {
        [DataMember]
        public string tipoRegistro;

        [DataMember]
        public string numeroPedidoPalm;

        [DataMember]
        public string codigoCliente;

        [DataMember]
        public string controleCgc;

        [DataMember]
        public string cgcCpf;

        [DataMember]
        public string dtPedido;

        [DataMember]
        public string dtEntrega;

        [DataMember]
        public string frete;

        [DataMember]
        public string codigoVendedor;

        [DataMember]
        public string pedidoCliente;

        [DataMember]
        public string operacao;

        [DataMember]
        public string entregaImediata;

        [DataMember]
        public string prazo;

        [DataMember]
        public string tabelaPreco;

        [DataMember]
        public string percDesconto;

        [DataMember]
        public string observacoes;

        [DataMember]
        public string codigoMensagem;

        [DataMember]
        public string codigoFilial;
    }
    #endregion

    #region CondicoesPagamentoPedido
    public class CondicoesPagamentoPedido
    {
        [DataMember]
        public string tipoRegistro;

        [DataMember]
        public string numeroPedidoPalm;

        [DataMember]
        public string prazoDiasParcela;

        [DataMember]
        public string dtVencimentoParcela;

        [DataMember]
        public string valorParcela;

        [DataMember]
        public string formaPagamento;
    }
    #endregion

    #region ItensPedido
    public class ItensPedido
    {
        [DataMember]
        public string tipoRegistro;

        [DataMember]
        public string numeroPedidoPalm;

        [DataMember]
        public string codigoProduto;

        [DataMember]
        public string quantidade;

        [DataMember]
        public string valorUnitario;

        [DataMember]
        public string percComissao;

        [DataMember]
        public string valorUnitarioTabelaPreco;
    }
    #endregion
}
