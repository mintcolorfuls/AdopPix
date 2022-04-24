using AdopPix.Models;
using System.Threading.Tasks;

namespace AdopPix.Procedure.IProcedure
{
    public interface IUserProfileProcedure
    {
        Task CreateAsync(UserProfile entity);
        Task<UserProfile> FindByIdAsync(string userId);
        Task UpdateAsync(UserProfile entity);
    }
}
