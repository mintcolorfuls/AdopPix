using AdopPix.DataAccess.Core.IRepository;
using AdopPix.DataAccess.Data;
using AdopPix.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdopPix.DataAccess.Core.Repositories
{
    public class UserProfileRepository : Repository<UserProfile>, IUserProfileRepository
    {
        public UserProfileRepository(ApplicationDbContext context, ILogger logger) 
            : base(context, logger)
        {
        }
        public override Task<IEnumerable<UserProfile>> GetAllAsync()
        {
            try
            {
                return base.GetAllAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return null;
            }  
        }
    }
}
