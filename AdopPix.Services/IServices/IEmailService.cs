using System.Threading.Tasks;

namespace AdopPix.Services.IServices
{
    public interface IEmailService
    {
        Task SendAsync(string from, string to, string subject, string body);
    }
}
