using AdopPix.Services.ModelService;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdopPix.Services.IServices
{
    public interface IAuctionHubService
    {
        Task UpdateClientsAsync(string auctionId, UpdateClientModelService model);
        Task NotificationByUserId(string from, IReadOnlyList<string> to, string auctionId, string description);
    }
}
