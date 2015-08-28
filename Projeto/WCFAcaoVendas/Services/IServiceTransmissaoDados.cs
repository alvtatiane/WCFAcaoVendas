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

    
}
