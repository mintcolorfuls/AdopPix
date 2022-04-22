using AdopPix.DataAccess.Core.IRepository;
using System.Threading.Tasks;

namespace AdopPix.DataAccess.Core.IConfiguration
{
    public interface IUnitOfWork
    {
        IUserProfileRepository UserProfile { get; }
        IPaymentLoggingRepository PaymentLogging { get; }
        ISocialMediaRepository SocialMedia { get; }
        ISocialMediaTypeRepository SocialMediaType { get; }
        Task CompleateAsync();
    }
}
  