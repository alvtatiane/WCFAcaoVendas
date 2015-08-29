using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFAcaoVendas.Services
{
    [ServiceContract]
    public interface IServiceInfoMensagem
    {
        [OperationContract]
        InfoMensagem[] Importar();
    }

    #region InfoMensagem
    [DataContract]
    public class InfoMensagem
    {
        public InfoMensagem(string tipoRegistro, string codigoMensagem, string referencia, string conteudo, string situacao)
        {
            TipoRegistro = tipoRegistro;
            CodigoMensagem = codigoMensagem;
            Referencia = referencia;
            Conteudo = conteudo;
            Situacao = situacao;
        }

        [DataMember]
        public string TipoRegistro { get; set; } /*Tem valor = 08*/

        [DataMember]
        public string CodigoMensagem { get; set; }

        [DataMember]
        public string Referencia { get; set; }

        [DataMember]
        public string Conteudo { get; set; }
        
        [DataMember]
        public string Situacao { get; set; }
    }
    #endregion
}
