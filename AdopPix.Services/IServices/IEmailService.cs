using System.Threading.Tasks;

namespace AdopPix.Services.IServices
{
    public interface IEmailService
    {
        string CreateTemplate(string templateType);
        string SetupConfirmEmailTemplate(string template, string url);
        string SetupChangeEmailTemplate(string template, string url);
        string SetupForgetPasswordTemplate(string template, string url);
        Task SendAsync(string from, string to, string subject, string body);
    }
}
