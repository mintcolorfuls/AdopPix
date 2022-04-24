using AdopPix.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdopPix.Procedure.IProcedure
{
    public interface ISocialMediaTypeProcedure
    {
        Task<Dictionary<int, string>> FindAsync();
        Task<SocialMediaType> FindByNameAsync(string name);
    }
}
