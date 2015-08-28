using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFAcaoVendas.Services
{
    [ServiceContract]
    public interface IServiceInfoDividas
    {
        [OperationContract]
        InfoDivida[] Importar(string codigo);
    }

    #region InfoDividas
    [DataContract]
    public class InfoDivida
    {
        public InfoDivida(string tipoRegistro, string filial, string modeloDocFiscal, string numeroDuplicata, string numeroParcela, string codigoCliente, string controleCgc, string dtVencimento, Single saldoTitulo, string numPedidoAndroid, string situacao)
        {
            TipoRegistro = tipoRegistro;
            Filial = filial;
            ModeloDocFiscal = modeloDocFiscal;
            NumeroDuplicata = numeroDuplicata;
            NumeroParcela = numeroParcela;
            CodigoCliente = codigoCliente;
            ControleCgc = controleCgc;
            DtVencimento = dtVencimento;
            SaldoTitulo = saldoTitulo;
            NumPedidoAndroid = numPedidoAndroid;
            Situacao = situacao;
        }

        [DataMember]
        public string TipoRegistro { get; set; }  /*Tem valor = 03*/

        [DataMember]
        public string Filial { get; set; }

        [DataMember]
        public string ModeloDocFiscal { get; set; }

        [DataMember]
        public string NumeroDuplicata { get; set; }

        [DataMember]
        public string NumeroParcela { get; set; }

        [DataMember]
        public string CodigoCliente { get; set; }

        [DataMember]
        public string ControleCgc { get; set; }

        [DataMember]
        public string DtVencimento { get; set; }

        [DataMember]
        public Single SaldoTitulo { get; set; }

        [DataMember]
        public string NumPedidoAndroid { get; set; }

        [DataMember]
        public string Situacao { get; set; }
    }
    #endregion
}
