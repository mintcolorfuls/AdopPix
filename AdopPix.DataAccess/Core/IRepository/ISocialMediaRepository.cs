using AdopPix.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdopPix.DataAccess.Core.IRepository
{
    public interface ISocialMediaRepository : IRepository<SocialMedia>
    {
        Task<IEnumerable<SocialMedia>> GetAllAsync(string userId);
        Task<SocialMedia> GetByUrlAsync(string url);
        Task<SocialMedia> GetByUrlAsync(string url, string userId);
    }
}
