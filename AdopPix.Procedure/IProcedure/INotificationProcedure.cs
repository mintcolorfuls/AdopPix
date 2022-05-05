using AdopPix.Models;
using System.Threading.Tasks;

namespace AdopPix.Procedure.IProcedure
{
    public interface INotificationProcedure
    {
        Task CreateAsync(Notification entity);
    }
}
