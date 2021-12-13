using System;
using System.IO;
using System.Net.Mail;

namespace ProjectEmail
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                MailMessage e_mail = new MailMessage(); //Relacionada ao email
                SmtpClient SmtpServer = new SmtpClient("smtp.live.com"); //Relacionada ao Servidor

                //Email Emissor:
                e_mail.From = new MailAddress("email@hotmail");

                //caminho em que está a lista de emails:
                var emails = new StreamReader("C:\\email\\email.txt");

                

                ////seleciona todos os emails da lista:
                foreach (var email in emails.ReadLine().Split(","))
                {
                    e_mail.To.Add(email);

                }

                // Assunto do email:
                e_mail.Subject = "ASSUNTO DO EMAIL NOVO"; 
                e_mail.IsBodyHtml = true;

                //Edição do corpo do e-mail (template)
                var body = File.ReadAllText("C:\\email\\HTMLPage1.html");
                body = body.Replace("@Name", "Nome_do_destinatário");
                body = body.Replace("@Descricao", "Uma chance imperdível para você!");

                e_mail.Body = body;

                //Configurações do servidor:
                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("email@hotmail", "senha");
                SmtpServer.EnableSsl = true;
                SmtpServer.Send(e_mail);

                Console.WriteLine("SEND MAIL");
            }
            catch (Exception e)
            {

                Console.WriteLine(e);
            }
        }
    }
}
