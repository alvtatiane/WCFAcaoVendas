﻿using System.Linq;
using System.Net.Mail;
using System.Web;
using WCFAcaoVendas.Services;

namespace WCFAcaoVendas.DAL
{
    public abstract class EmailDAL
    {
        public static void Enviar(Email email)
        {
            email.Destinatarios = email.Destinatarios.Distinct().ToList(); //remove repetidos, caso tenha

            email.Mensagem = email.Mensagem.Replace("\r\n", "<br />").Replace("\r", "").Replace("\n", "");
            var mail = new MailMessage();
            foreach (var destinatario in email.Destinatarios)
            {
                mail.To.Add(destinatario);
            }

            //mail.CC.Add(copia);

            mail.From = new MailAddress("acaovendas@methodsinformatica.com.br", "Ação Vendas - Method's Informática", System.Text.Encoding.UTF8);
            mail.Subject = email.Assunto;
            mail.SubjectEncoding = System.Text.Encoding.UTF8;
            mail.Body = email.Mensagem + Assinatura;
            mail.BodyEncoding = System.Text.Encoding.UTF8;
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.High; //Prioridade do E-Mail
            var client = new SmtpClient
            {
                Credentials = new System.Net.NetworkCredential("acaovendas@methodsinformatica.com.br", "mts@854"),
                Port = 26,
                Host = "mail.methodsinformatica.com.br"
            }; //Adicionando as credenciais do seu e-mail e senha:
            //client.EnableSsl = true; //Gmail trabalha com Server Secured Layer
            try
            {
#if !DEBUG
                {
                    client.Send(mail);
                }
#endif
                //model.Nome = "";
                //model.Telefone = "";
                //model.Email = "";
                //model.Mensagem = "";
                //return RedirectToAction("FaleConosco");
            }
            catch
            {
                throw new HttpException();
            }
        }

        public static string Assinatura
        {
            get
            {
                return @"<br /><br /><br /><span style=""font-size: 11pt; color: #1f497d;""></span>
<div class=""im"">
<table border=""0"" cellpadding=""0"">
    <tbody>
        <tr>
            <td valign=""top"" style=""padding: 0.75pt;"">
            <p><img alt="""" src=""data:image/png;base64,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"" /></p>
            </td>
            <td valign=""top"" style=""width: 100%; padding: 0.75pt;"">
            <p style=""margin: 1.5pt;""><strong><span style=""font-size: 10.5pt; color: black;"">Method's Informática LTDA.</span></strong><span style=""font-size: 8.5pt; color: #777777;""><span style=""text-decoration: underline;""></span><span style=""text-decoration: underline;""></span></span></p>
            <p style=""margin: 1.5pt;""><span style=""font-size: 8.5pt; color: #777777;"">Rua Marechal Deodoro, 857, conjuntos 1001 e 1002, Centro - Curitiba - PR.</span></p>
            <p style=""margin: 1.5pt;""><span style=""font-size: 8.5pt; color: #777777;"">Tel.: <a target=""_blank"" value=""+554121419654"" href=""tel:%2B55%2041%202141-9654"">+55 41 3324-4033</a><span style=""text-decoration: underline;""></span><span style=""text-decoration: underline;""></span></span></p>
            <p style=""margin: 1.5pt;""><span style=""font-size: 8.5pt; color: #777777;""><a target=""_blank"" href=""mailto:acaovendas@methodsinformatica.com.br"">acaovendas@methodsinformatica.com.br</a><span style=""text-decoration: underline;""></span><span style=""text-decoration: underline;""></span></span></p>
            <p style=""margin: 1.5pt;""><span style=""font-size: 8.5pt; color: #0070c0;""><a target=""_blank"" href=""http://www.methodsinformatica.com.br/"">http://www.methodsinformatica.com.br</a></span></p>
            </td>
        </tr>
        <tr>
            <td style=""padding: 0.75pt;"" colspan=""3"">
            <p><em><span style=""font-size: 8.5pt; color: black;"">A informação contida neste e-mail é confidencial e destinada exclusivamente ao destinatário a quem foi endereçado. Caso tenha recebido este e-mail por engano, favor nos comunicar imediatamente e, posteriormente, apague-o, pois a disseminação, uso, impressão ou cópia do seu conteúdo é expressamente proibida.</span></em></p>
            </td>
        </tr>
    </tbody>
</table>
</div>";
            }
        }
    }
}