using AdopPix.Models;
using System.Threading.Tasks;

namespace AdopPix.DataAccess.Core.IRepository
{
    public interface ISocialMediaRepository : IRepository<SocialMedia>
    {
        Task<SocialMedia> GetByUrlAsync(string url);
    }
}
