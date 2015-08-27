using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFAcaoVendas.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IServiceInfoDividas" in both code and config file together.
    [ServiceContract]
    public interface IServiceInfoDividas
    {
        [OperationContract]
        void DoWork();
    }

    #region InfoDividas
    public class InfoDividas
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
}
