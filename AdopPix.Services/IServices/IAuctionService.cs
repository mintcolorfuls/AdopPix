using System.Threading.Tasks;

namespace AdopPix.Services.IServices
{
    public interface IAuctionService
    {
        Task CreateAuction(string auctionId, string userId, string title, int hourId, decimal openingPrice, decimal hotClose, string description);
    }
}
