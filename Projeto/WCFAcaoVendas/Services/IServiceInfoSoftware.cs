using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFAcaoVendas.Services
{
    [ServiceContract]
    public interface IServiceInfoSoftware
    {
        [OperationContract]
        string Importa(string numeroVersao); 
    }

    [DataContract]
    public class InfoSoftware
    {
        public InfoSoftware(DateTime dataCadastro, DateTime dataVersao, string numeroVersao, string link, string nomeEmpresa)
        {
            DataCadastro = dataCadastro;
            DataVersao = dataVersao;
            NumeroVersao = numeroVersao;
            Link = link;
            NomeEmpresa = nomeEmpresa;
        }

        [DataMember]
        public DateTime DataCadastro { get; set; }

        [DataMember]
        public DateTime DataVersao { get; set; }

        [DataMember]
        public string NumeroVersao { get; set; }

        [DataMember]
        public string Link { get; set; }

        [DataMember]
        public string NomeEmpresa { get; set; }
    }
}
