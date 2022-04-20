using AdopPix.Services.IServices;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
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

        public string CreateTemplate(string templateType)
        {
            string fileName = string.Empty;

            switch (templateType)
            {
                case "ConfirmEmail" : fileName = templateType; break;
                case "ChangeEmail": fileName = templateType; break;
                case "ForgetPassword": fileName = templateType; break;
                default: throw new Exception("templateType not found.");
            }

            string FilePath = $"{Directory.GetCurrentDirectory()}\\Template\\Email\\{fileName}.html";
            StreamReader reader = new StreamReader(FilePath);
            string content = reader.ReadToEnd();
            reader.Close();

            return content;
        }

        public string SetupConfirmEmailTemplate(string template, string url)
        {
            return template.Replace("[urlConfirmEmail]", url);
        }

        public string SetupChangeEmailTemplate(string template, string url)
        {
            return template.Replace("[url]", url);
        }

        public string SetupForgetPasswordTemplate(string template, string url)
        {
            return template.Replace("[url]", url);
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
