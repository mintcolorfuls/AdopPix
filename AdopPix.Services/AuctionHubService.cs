using AdopPix.Hubs;
using AdopPix.Services.IServices;
using AdopPix.Services.ModelService;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace AdopPix.Services
{
    public class AuctionHubService : IAuctionHubService
    {
        private readonly IHubContext<AuctionHub> hubContext;

        public AuctionHubService(IHubContext<AuctionHub> hubContext)
        {
            this.hubContext = hubContext;
        }
        public async Task UpdateClientsAsync(string auctionId, UpdateClientModelService model)
        {
            await hubContext.Clients.All.SendAsync(auctionId, new { avatarName = model.AvatarName,
                                                                    username = model.UserName,
                                                                    amount = model.Amount,
                                                                    created = model.Created
                                                                  });
        }
    }
}
