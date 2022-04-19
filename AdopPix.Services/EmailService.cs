using AdopPix.Services.IServices;
using Microsoft.Extensions.Configuration;
using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace AdopPix.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration configuration;

        public EmailService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public async Task SendAsync(string from, string to, string subject, string body)
        {
            var massage = new MailMessage(from, to, subject, body);

            massage.IsBodyHtml = true;

            string host = configuration["SMTP_Host"];
            string port = configuration["SMTP_Port"];
            string user = configuration["SMTP_User"];
            string password = configuration["SMTP_Password"];

            using (var emailClient = new SmtpClient(host, Convert.ToInt32(port)))
            {
                emailClient.Credentials = new NetworkCredential(user, password);
                await emailClient.SendMailAsync(massage);
            }
        }
    }
}
