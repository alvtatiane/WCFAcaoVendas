using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFAcaoVendas.Services
{
    [ServiceContract]
    public interface IServiceInfoPreco
    {
        [OperationContract]
        InfoPreco[] Importar(string codigo);
    }

    #region InfoPrecos
    [DataContract]
    public class InfoPreco
    {
        public InfoPreco(string tipoRegistro, string tabelaPreco, string codigoProduto, Single valorAVistaProduto, string situacao)
        {
            TipoRegistro = tipoRegistro;
            TabelaPreco = tabelaPreco;
            CodigoProduto = codigoProduto;
            ValorAVistaProduto = valorAVistaProduto;
            Situacao = situacao;
        }

        [DataMember]
        public string TipoRegistro { get; set; } /*Tem valor = 06*/

        [DataMember]
        public string TabelaPreco { get; set; }

        [DataMember]
        public string CodigoProduto { get; set; }

        [DataMember]
        public Single ValorAVistaProduto { get; set; }

        [DataMember]
        public string Situacao { get; set; }
    }
    #endregion
}
