using AdopPix.Hubs;
using AdopPix.Models;
using AdopPix.Procedure.IProcedure;
using AdopPix.Services.IServices;
using AdopPix.Services.ModelService;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdopPix.Services
{
    public class AuctionHubService : IAuctionHubService
    {
        private readonly IHubContext<AuctionHub> hubContext;
        private readonly UserManager<User> userManager;
        private readonly IUserProfileProcedure userProfileProcedure;

        public AuctionHubService(IHubContext<AuctionHub> hubContext,
                                 UserManager<User> userManager,
                                 IUserProfileProcedure userProfileProcedure)
        {
            this.hubContext = hubContext;
            this.userManager = userManager;
            this.userProfileProcedure = userProfileProcedure;
        }

        public async Task NotificationByUserId(string from, IReadOnlyList<string> to, string auctionId, string description)
        {
            var user = await userManager.FindByIdAsync(from);
            var profile = await userProfileProcedure.FindByIdAsync(from);            

            await hubContext.Clients.Users(to).SendAsync("auctionNotification", new { username = user.UserName, description , avatarName = profile.AvatarName });
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
