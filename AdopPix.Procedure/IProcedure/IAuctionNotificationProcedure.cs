using AdopPix.Models;
using System.Threading.Tasks;

namespace AdopPix.Procedure.IProcedure
{
    public interface IAuctionNotificationProcedure
    {
        Task Create(AuctionNotification entity);
    }
}
