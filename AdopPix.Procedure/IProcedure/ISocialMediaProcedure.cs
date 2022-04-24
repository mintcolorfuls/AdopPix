using AdopPix.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdopPix.Procedure.IProcedure
{
    public interface ISocialMediaProcedure
    {
        Task CreateAsync(SocialMedia entity);
        Task<List<SocialMedia>> FindById(string userId);
        Task DeleteAsync(SocialMedia entity);
    }
}
