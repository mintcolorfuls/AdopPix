using AdopPix.Models;
using System.Threading.Tasks;

namespace AdopPix.Procedure.IProcedure
{
    public interface IAuctionProcedure
    {
        Task CreateAsync(Auction auction);
        Task FindByIdAsync(Auction auction);
        Task FindAll(Auction auction);
        Task DeleteAsync(Auction auction);
        Task UpdateAsync(Auction auction);

    }
}
