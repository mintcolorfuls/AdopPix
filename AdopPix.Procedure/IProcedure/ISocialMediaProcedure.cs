using AdopPix.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdopPix.Procedure.IProcedure
{
    public interface ISocialMediaProcedure
    {
        Task CreateAsync(SocialMedia entity);
        Task<List<SocialMedia>> FindByIdAsync(string userId);
        Task<SocialMedia> FindByUrlAsync(string userId, string url);
        Task DeleteAsync(SocialMedia entity);
    }
}
