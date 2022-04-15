using AdopPix.DataAccess.Core.IRepository;
using AdopPix.DataAccess.Data;
using AdopPix.Models;
using Microsoft.Extensions.Logging;

namespace AdopPix.DataAccess.Core.Repositories
{
    internal class UserProfileRepository : Repository<UserProfile>, IUserProfileRepository
    {
        public UserProfileRepository(ApplicationDbContext context, ILogger logger) 
            : base(context, logger)
        {
        }
    }
}
