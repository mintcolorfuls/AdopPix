using AdopPix.Hubs;
using AdopPix.Models;
using AdopPix.Procedure.IProcedure;
using AdopPix.Services.IServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdopPix.Services
{
    public class NotificationService : INotificationService
    {
        private readonly IHubContext<NotificationHub> hubContext;
        private readonly INotificationProcedure notificationProcedure;
        private readonly UserManager<User> userManager;
        private readonly IUserProfileProcedure userProfileProcedure;

        public NotificationService(IHubContext<NotificationHub> hubContext,
                                   INotificationProcedure notificationProcedure,
                                   UserManager<User> userManager,
                                   IUserProfileProcedure userProfileProcedure)
        {
            this.hubContext = hubContext;
            this.notificationProcedure = notificationProcedure;
            this.userManager = userManager;
            this.userProfileProcedure = userProfileProcedure;
        }
        public async Task NotificationByUserIdAsync(string from, string to, string description, string redirectToUrl)
        {
            Notification notification = new Notification
            {
                From = from,
                To = to,
                Description = description,
                RedirectToUrl = redirectToUrl,
                isOpen = false,
                Created = DateTime.Now
            };
            await notificationProcedure.CreateAsync(notification);
            var user = await userManager.FindByIdAsync(from);
            var profile = await userProfileProcedure.FindByIdAsync(user.Id);
            await hubContext.Clients.User(to).SendAsync("notification", new { avatarName = profile.AvatarName, username = user.UserName, description, redirectToUrl });
        }
    }
}
