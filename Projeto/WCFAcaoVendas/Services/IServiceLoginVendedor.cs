using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFAcaoVendas.Services
{
    [ServiceContract]
    public interface IServiceLoginVendedor
    {
        //Metodo usado para cadastro, alteracao de login, marcar o vendedor como atualizado, atualiza a versao do sw
        [OperationContract]
        void Exporta(InfoLoginVendedor infoLogin);
    }

    #region InfoLoginVendedor
    [DataContract]
    public class InfoLoginVendedor
    {
        public InfoLoginVendedor(string codigoVendedor, string nomeVendedor, string filial, string login, string senha, string numUltimoPedido, string versaoSoftware, string numSerieAparelho, int atualizado, string situacao)
        {
            CodigoVendedor = codigoVendedor;
            NomeVendedor = nomeVendedor;
            Filial = filial;
            Login = login;
            Senha = senha;
            NumUltimoPedido = numUltimoPedido;
            VersaoSoftware = versaoSoftware;
            NumSerieAparelho = numSerieAparelho;
            Atualizado = atualizado;
            Situacao = situacao;
        }

        [DataMember]
        public string CodigoVendedor { get; set; }

        [DataMember]
        public string NomeVendedor { get; set; }

        [DataMember]
        public string Filial { get; set; }

        [DataMember]
        public string Login { get; set; }

        [DataMember]
        public string Senha { get; set; }

        [DataMember]
        public string NumUltimoPedido { get; set; }

        [DataMember]
        public string VersaoSoftware { get; set; }

        [DataMember]
        public string NumSerieAparelho { get; set; }

        [DataMember]
        public int Atualizado { get; set; }

        [DataMember]
        public string Situacao { get; set; }
    }
    #endregion
}
