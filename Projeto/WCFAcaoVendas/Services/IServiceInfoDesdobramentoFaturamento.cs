using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFAcaoVendas.Services
{
    [ServiceContract]
    public interface IServiceInfoDesdobramentoFaturamento
    {
        [OperationContract]
        InfoDesdobramentoFaturamento[] Importar(string codigo);
    }

    #region InfoDesdobramentoFaturamento
    [DataContract]
    public class InfoDesdobramentoFaturamento
    {
        public InfoDesdobramentoFaturamento(string tipoRegistro, string codigoVendedor, string codigoCliente, string controleCgc, string numPedidoInterno, string numPedidoAndroid, string dtPedido, string filial, string modeloDocFiscal, string numeroDuplicata, string numeroParcela, Single valorParcela, string dtVencimento, string situacao)
        {
            TipoRegistro = tipoRegistro;
            CodigoVendedor = codigoVendedor;
            CodigoCliente = codigoCliente;
            ControleCgc = controleCgc;
            NumPedidoInterno = numPedidoInterno;
            NumPedidoAndroid = numPedidoAndroid;
            DtPedido = dtPedido;
            Filial = filial;
            ModeloDocFiscal = modeloDocFiscal;
            NumeroDuplicata = numeroDuplicata;
            NumeroParcela = numeroParcela;
            ValorParcela = valorParcela;
            DtVencimento = dtVencimento;
            Situacao = situacao;
        }

        [DataMember]
        public string TipoRegistro { get; set; } /*Tem valor = 07*/

        [DataMember]
        public string CodigoVendedor { get; set; }

        [DataMember]
        public string CodigoCliente { get; set; }

        [DataMember]
        public string ControleCgc { get; set; }

        [DataMember]
        public string NumPedidoInterno { get; set; }

        [DataMember]
        public string NumPedidoAndroid { get; set; }

        [DataMember]
        public string DtPedido { get; set; }

        [DataMember]
        public string Filial { get; set; }

        [DataMember]
        public string ModeloDocFiscal { get; set; }

        [DataMember]
        public string NumeroDuplicata { get; set; }

        [DataMember]
        public string NumeroParcela { get; set; }

        [DataMember]
        public Single ValorParcela { get; set; }

        [DataMember]
        public string DtVencimento { get; set; }

        [DataMember]
        public string Situacao { get; set; }
    }
    #endregion
}
