using AdopPix.DataAccess.Core.IRepository;
using AdopPix.DataAccess.Data;
using AdopPix.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;

namespace AdopPix.DataAccess.Core.Repositories
{
    public class SocialMediaTypeRepository : Repository<SocialMediaType>, ISocialMediaTypeRepository
    {
        public SocialMediaTypeRepository(ApplicationDbContext context, ILogger logger) : base(context, logger)
        {
        }

        public async Task<SocialMediaType> GetByNameAsync(string name)
        {
            return await context.SocialMediaTypes.Where(f => f.Title == name).FirstOrDefaultAsync();
        }
    }
}
