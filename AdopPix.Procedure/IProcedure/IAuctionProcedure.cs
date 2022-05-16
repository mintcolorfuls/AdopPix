using AdopPix.Models;
using AdopPix.Models.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdopPix.Procedure.IProcedure
{
    public interface IAuctionProcedure
    {
        Task CreateAsync(Auction auction);
        Task CreateImageAsync(AuctionImage auctionImage);
        Task <Auction> FindByIdAsync(string auctionId);

        Task<List<Auction>> GetAllAsync();
        Task<List<AuctionImage>> GetAllImageAsync();
        Task <AuctionViewModel> FindByUserIdAsync(string userId);
        Task <AuctionImage> FindImageByIdAsync(string auctionId);
        Task FindAll(Auction auction);
        Task DeleteAsync(Auction auction);
        Task UpdateAsync(Auction entity);


    }
}
