using AdopPix.Models;
using System.Threading.Tasks;

namespace AdopPix.DataAccess.Core.IRepository
{
    public interface ISocialMediaTypeRepository : IRepository<SocialMediaType>
    {
        Task<SocialMediaType> GetByNameAsync(string name);
    }
}
