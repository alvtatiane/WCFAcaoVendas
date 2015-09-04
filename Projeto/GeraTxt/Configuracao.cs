using System;
using System.Configuration;

namespace ManipulaTxt
{
    public class Configuracao
    {
        private static string DiretorioBase
        {
            get { return AppDomain.CurrentDomain.BaseDirectory; }
        }

        private static string Separador
        {
            get { return System.IO.Path.PathSeparator.ToString(); }
        }

        public string DiretorioTxtCobolCompleto
        {
            get { return ConfigurationManager.AppSettings["txtExportaPath"] + ConfigurationManager.AppSettings["nomeArquivoTxtExporta"]; }
        }

        public string DiretorioTxtPedidosCompleto
        {
            get { return ConfigurationManager.AppSettings["txtImportaPath"] + ConfigurationManager.AppSettings["nomeArquivoTxtImporta"]; }
        }

        private static string NomeTxtLogs
        {
            get { return DateTime.Now.ToString("yyyy-MM") + ".txt"; }
        }

        public static string DiretorioTxtLogsCompleto
        {
            get { return ConfigurationManager.AppSettings["txtLogPath"] + NomeTxtLogs; }
        }
    }
}
