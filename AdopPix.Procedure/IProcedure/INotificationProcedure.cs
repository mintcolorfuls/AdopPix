using AdopPix.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdopPix.Procedure.IProcedure
{
    public interface INotificationProcedure
    {
        Task CreateAsync(Notification entity);
        Task<List<Notification>> FindByUserIdAsync(string userId);
    }
}
