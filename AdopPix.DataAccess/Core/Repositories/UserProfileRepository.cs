using AdopPix.DataAccess.Core.IRepository;
using AdopPix.DataAccess.Data;
using AdopPix.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace AdopPix.DataAccess.Core.Repositories
{
    public class UserProfileRepository : Repository<UserProfile>, IUserProfileRepository
    {
        public UserProfileRepository(ApplicationDbContext context, ILogger logger) 
            : base(context, logger)
        {
        }
        public override Task<bool> CreateAsync(UserProfile entity)
        {
            try
            {
                return base.CreateAsync(entity);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return base.CreateAsync(entity);
            }
            
        }
    }
}
