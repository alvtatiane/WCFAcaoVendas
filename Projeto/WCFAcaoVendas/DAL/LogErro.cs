using System;
using System.Configuration;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Text;

namespace WCFAcaoVendas.DAL
{
    public abstract class LogErro
    {
        public static void Registrar(string mensagem)
        {
            var fullName = "";
            var stackFrame = new StackFrame(1);
            Type declaringType = stackFrame.GetMethod().DeclaringType;
            if (declaringType != null)
            {
                fullName += declaringType.FullName;
            }

            fullName += "." + stackFrame.GetMethod().Name + "()";

            var log = new StringBuilder();

            log.AppendLine("++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
            log.AppendLine(DateTime.Now.ToString("dd/MM/yyyy - HH:mm:ss"));
            log.AppendLine(fullName);
            log.AppendLine(mensagem);
            log.AppendLine("++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");

            string dir = ConfigurationManager.AppSettings["logPath"];
            string fileName = string.Format("log_" + DateTime.Now.Year + "_" + DateTime.Now.Month.ToString(CultureInfo.InvariantCulture).PadLeft(2, '0') + ".spflog");

            string path = Path.Combine(dir, fileName);

            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            var writer = new StreamWriter(path, true);
            writer.Write(log);
            writer.Close();
        }
    }
}