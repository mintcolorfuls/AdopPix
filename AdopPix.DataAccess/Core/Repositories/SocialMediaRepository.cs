using AdopPix.DataAccess.Core.IRepository;
using AdopPix.DataAccess.Data;
using AdopPix.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;

namespace AdopPix.DataAccess.Core.Repositories
{
    public class SocialMediaRepository : Repository<SocialMedia>, ISocialMediaRepository
    {
        public SocialMediaRepository(ApplicationDbContext context, ILogger logger) : base(context, logger)
        {
            
        }
        public async Task<SocialMedia> GetByUrlAsync(string url)
        {
            return await context.SocialMedias.Where(f => f.Url == url).FirstOrDefaultAsync();
        }
    }
}
