using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace app_gymManager
{
    public static class email
    {
        public static void EnviarEmail( string destinatarioEmail, string assunto, string corpo)
        {
            string remetenteEmail = "";
            string senha = "";
            try
            {
                var smtpClient = new SmtpClient("smtp-mail.outlook.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential(remetenteEmail, senha),
                    EnableSsl = true,
                };

                var mensagem = new MailMessage(remetenteEmail, destinatarioEmail)
                {
                    Subject = assunto,
                    Body = corpo
                };

                smtpClient.Send(mensagem);
                MessageBox.Show("E-mail enviado com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao enviar e-mail: {ex.Message}");
            }
        }
    }
}
