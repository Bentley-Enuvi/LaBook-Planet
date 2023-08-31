using LaBook_Planet.Library.Core.Services.Interfaces;
using MimeKit;
using MailKit.Net.Smtp;
//using System.Net.Mail;

namespace LaBook_Planet.Library.Core.Services.Implementations
{
   
    public class EmailService : IEmailService
    {
         private readonly IConfiguration _config;
        public EmailService(IConfiguration config)
        {
            _config = config;
        }

        public async Task<bool> SendAsync(string recipientEmail, string subject, string body)
        {
            try
            {
                var sender = _config.GetSection("EmailSettings:sender").Value;
                var port = Convert.ToInt32(_config.GetSection("EmailSettings:sender:port").Value); // the Convert.ToInt32 rids off the complain in port and true parameters below
                var host = _config.GetSection("EmailSettings:sender:host").Value;
                var appPassword = _config.GetSection("EmailSettings:sender:appPassword").Value;

                var email = new MimeMessage();
                email.Sender = MailboxAddress.Parse(sender);
                email.To.Add(MailboxAddress.Parse(recipientEmail));
                email.Subject = subject;

                var builder = new BodyBuilder();
                builder.HtmlBody = body;
                email.Body = builder.ToMessageBody();

                using (var smtp = new SmtpClient())
                {
                    smtp.CheckCertificateRevocation = true;
                    await smtp.ConnectAsync(host, port, true);
                    await smtp.AuthenticateAsync(sender, appPassword);
                    await smtp.SendAsync(email);
                    await smtp.DisconnectAsync(true);
                }

                return true;
            }catch
            {
                throw;
            }
        }
    }

}
