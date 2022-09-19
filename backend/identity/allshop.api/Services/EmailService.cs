using System;
using System.Net;
using System.Net.Mail;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using allshop.api.Services.Contracts;

namespace allshop.api.Services
{
    public class EmailService : IDisposable, IEmailService
    {
        private SmtpClient _client;
        public StringBuilder _body;

        public EmailService()
        {
            _body = new StringBuilder();
            _client = new SmtpClient();
        }

        public void Dispose()
        {
            _body.Clear();
            _client.Dispose();
        }

        public async Task<bool> SendEmailGmailAsync(string fullname, string receiverEmail, string subject)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.To.Add(receiverEmail);
                mail.From = new MailAddress("all.leonardo.lucero@email.com", " ALLDEV", Encoding.UTF8);
                mail.Subject = subject;
                mail.Body = _body.ToString();
                mail.IsBodyHtml = true;
                mail.Priority = MailPriority.High;
                _client.Host = "smtp.gmail.com";
                _client.Port = 587;
                // Puerto SMTP de Gmail(TLS): 587
                // Puerto SMTP de Gmail(SSL): 465
                _client.Credentials = new NetworkCredential("all.leonardo.lucero@gmail.com", "canada.1980");
                _client.EnableSsl = true;
                _client.UseDefaultCredentials = false;
                await _client.SendMailAsync(mail);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<bool> SendEmailAsync(string fullname, string receiverEmail, string subject)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.To.Add(receiverEmail);
                mail.From = new MailAddress("lab-cenasis@gendarmeria.gob.ar", "ADMINSIGESAN", Encoding.UTF8);
                mail.Subject = subject;
                mail.Body = _body.ToString();
                mail.IsBodyHtml = true;
                mail.Priority = MailPriority.High;
                _client.Host = "smtp.gendarmeria.gob.ar";
                _client.Port = 587;
                _client.Credentials = new NetworkCredential("lab-cenasis@gendarmeria.gob.ar", "Enero.2022");
                _client.EnableSsl = true;
                _client.UseDefaultCredentials = false;
                await _client.SendMailAsync(mail);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<bool> SendWelcomeEmail(string fullname, string email)
        {
            using EmailService emailService = new EmailService();
            emailService._body.Append("<html>");
            emailService._body.Append($"Hello {fullname}! <br /><br />");
            emailService._body.Append("Thank you for signing up!  <br /><br />");
            emailService._body.Append("Regards <br /><br />");
            emailService._body.Append("Company brand");
            emailService._body.Append("</html>");
            return await emailService.SendEmailAsync(fullname, email, $"Welcome {fullname}");
        }
        public async Task<bool> SendRecoveryLinkEmail(string recoveryLink, string fullName, string email)
        {

            using EmailService emailService = new();
            emailService._body.Append("<html>");
            emailService._body.Append($"Hello {fullName}! <br /><br />");
            emailService._body.Append("Please click on the link below o change your password<br /><br />");
            emailService._body.Append("<a href='" + recoveryLink + "' target='_blank'>Click here</a> <br /><br />");
            emailService._body.Append("This link is available for 24h <br /><br />");
            emailService._body.Append("Regards <br /><br />");
            emailService._body.Append("Company brand");
            emailService._body.Append("</html>");

            return await emailService.SendEmailAsync(fullName, email, $"Password recovery...");

        }

        
    }
}
