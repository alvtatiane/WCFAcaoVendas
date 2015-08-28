using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFAcaoVendas.Services
{
    [ServiceContract]
    public interface IServiceInfoProduto
    {
        [OperationContract]
        InfoProduto[] Importar(string codigo);
    }


    #region InfoProduto
    [DataContract]
    public class InfoProduto
    {
        public InfoProduto(string tipoRegistro, string codigoVendedor, string codigoProduto, string nomeProduto, string unidadeProduto, Single percComissao, string situacao)
        {
            TipoRegistro = tipoRegistro;
            CodigoVendedor = codigoVendedor;
            CodigoProduto = codigoProduto;
            NomeProduto = nomeProduto;
            UnidadeProduto = unidadeProduto;
            PercComissao = percComissao;
            Situacao = situacao;
        }

        [DataMember]
        public string TipoRegistro { get; set; }  /*Tem valor = 05*/

        [DataMember]
        public string CodigoVendedor { get; set; }

        [DataMember]
        public string CodigoProduto { get; set; }

        [DataMember]
        public string NomeProduto { get; set; }

        [DataMember]
        public string UnidadeProduto { get; set; }

        //[DataMember]
        //public Single QuantidadeUnidEmbalagem { get; set; }

        //[DataMember]
        //public Single PesoLiquidoUnidade { get; set; } 

        //[DataMember]
        //public Single PesoEmbalagem { get; set; } 

        [DataMember]
        public Single PercComissao { get; set; } 

        //[DataMember]
        //public string CodigoBarraEan13 { get; set; } 

        [DataMember]
        public string Situacao { get; set; } 
    }
    #endregion

}
