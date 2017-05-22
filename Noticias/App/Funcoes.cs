using System;
using System.Net;
using System.Net.Mail;
using System.Web.UI;


namespace Noticias.App
{
    public class Funcoes
    {
        public static void mostrarMensagem(Page pagina, string mensagem)
        {
            ScriptManager.RegisterStartupScript(pagina, pagina.GetType(), Guid.NewGuid().ToString(), "alert('" + mensagem + "');", true);
        }

        public static bool verUsuarioLogado(Usuario usuario)
        {
            return (usuario != null) && (usuario.Usu_ativo);
        }

        public static bool enviarEmail(string email, string assunto, string mensagem)
        {
            if (string.IsNullOrEmpty(email))
                return false;

            try
            {
                SmtpClient client = new SmtpClient("smpt.gmail.com", 587);
                client.EnableSsl = true;
                MailAddress remetente = new MailAddress("tiagonfs@gmail.com", "Tiago");
                MailAddress destinatario = new MailAddress(email, "Tiago");
                MailMessage mailMesssage = new MailMessage(remetente, destinatario);
                mailMesssage.Subject = assunto;
                mailMesssage.Body = mensagem;
                mailMesssage.IsBodyHtml = true;

                // Credenciais
                NetworkCredential credencial = new NetworkCredential("tiagonfs@gmail.com", "<senha>"); // colocar a senha do meu email
                client.Credentials = credencial;
                client.Send(mailMesssage);
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
