using AdopPix.Services.IServices;
using System.Threading.Tasks;

namespace AdopPix.Services
{
    public class EmailService : IEmailService
    {
        public Task SendAsync(string from, string to, string subject, string body)
        {
            throw new System.NotImplementedException();
        }
    }
}
