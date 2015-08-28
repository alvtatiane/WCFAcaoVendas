using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFAcaoVendas.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IServiceInfoNF" in both code and config file together.
    [ServiceContract]
    public interface IServiceInfoNF
    {
        [OperationContract]
        InfoNF[] Importar(string codigo);
    }

    #region InfoNF
    [DataContract]
    public class InfoNF
    {
        public InfoNF(string tipoRegistro, string codigoVendedor, string filial, string modeloDocFiscal, string numNF, string codigoCliente, string controleCgc, string numPedidoInterno, string codigoProduto, string numPedidoAndroid, string dtPedido, Single quantidadePedido, Single quantidadeAtendida, Single quantidadeProdutoItem, Single valorTotalProdutoItem, string dtEmissao, string situacao)
        {
            TipoRegistro = tipoRegistro;
            CodigoVendedor = codigoVendedor;
            Filial = filial;
            ModeloDocFiscal = modeloDocFiscal;
            NumNF = numNF;
            CodigoCliente = codigoCliente;
            ControleCgc = controleCgc;
            NumPedidoInterno = numPedidoInterno;
            CodigoProduto = codigoProduto;
            NumPedidoAndroid = numPedidoAndroid;
            DtPedido = dtPedido;
            QuantidadePedido = quantidadePedido;
            QuantidadeAtendida = quantidadeAtendida;
            QuantidadeProdutoItem = quantidadeProdutoItem;
            ValorTotalProdutoItem = valorTotalProdutoItem;
            DtEmissao = dtEmissao;
            Situacao = situacao;
        }

        [DataMember]
        public string TipoRegistro { get; set; } /*Tem valor = 04*/

        [DataMember]
        public string CodigoVendedor { get; set; }

        [DataMember]
        public string Filial { get; set; }

        [DataMember]
        public string ModeloDocFiscal { get; set; }

        [DataMember]
        public string NumNF { get; set; }

        [DataMember]
        public string CodigoCliente { get; set; }

        [DataMember]
        public string ControleCgc { get; set; }

        [DataMember]
        public string NumPedidoInterno { get; set; }

        [DataMember]
        public string CodigoProduto { get; set; }

        [DataMember]
        public string NumPedidoAndroid { get; set; }

        [DataMember]
        public string DtPedido { get; set; }

        [DataMember]
        public Single QuantidadePedido { get; set; }

        [DataMember]
        public Single QuantidadeAtendida { get; set; }

        [DataMember]
        public Single QuantidadeProdutoItem { get; set; }

        [DataMember]
        public Single ValorTotalProdutoItem { get; set; }

        [DataMember]
        public string DtEmissao { get; set; }

        [DataMember]
        public string Situacao { get; set; }
    }
    #endregion
}
