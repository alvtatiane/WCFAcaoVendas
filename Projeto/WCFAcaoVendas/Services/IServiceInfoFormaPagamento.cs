using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFAcaoVendas.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IServiceInfoFormaPagamento" in both code and config file together.
    [ServiceContract]
    public interface IServiceInfoFormaPagamento
    {
        [OperationContract]
        InfoFormaPagamento[] Importar(string codigo);
    }

    #region InfoFormaPagamento
    [DataContract]
    public class InfoFormaPagamento
    {
        public InfoFormaPagamento(string tipoRegistro, string codigoVendedor, string numTabelaPreco, string prazoTabelaPreco, string identificacaoTabela, Single percJurosTabelaPreco, Single percDescontoTabelaPreco, string situacao)
        {
            TipoRegistro = tipoRegistro;
            CodigoVendedor = codigoVendedor;
            NumTabelaPreco = numTabelaPreco;
            PrazoTabelaPreco = prazoTabelaPreco;
            IdentificacaoTabela = identificacaoTabela;
            PercJurosTabelaPreco = percJurosTabelaPreco;
            PercDescontoTabelaPreco = percDescontoTabelaPreco;
            Situacao = situacao;
        }

        [DataMember]
        public string TipoRegistro { get; set; } /*Tem valor = 02*/

        [DataMember]
        public string CodigoVendedor { get; set; }

        [DataMember]
        public string NumTabelaPreco { get; set; }

        [DataMember]
        public string PrazoTabelaPreco { get; set; }

        [DataMember]
        public string IdentificacaoTabela { get; set; }

        [DataMember]
        public Single PercJurosTabelaPreco { get; set; }

        [DataMember]
        public Single PercDescontoTabelaPreco { get; set; }

        [DataMember]
        public string Situacao { get; set; }
    }
    #endregion
}
