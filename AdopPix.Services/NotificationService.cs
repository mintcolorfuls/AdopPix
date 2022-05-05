using AdopPix.Hubs;
using AdopPix.Models;
using AdopPix.Procedure.IProcedure;
using AdopPix.Services.IServices;
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

        public NotificationService(IHubContext<NotificationHub> hubContext,
                                   INotificationProcedure notificationProcedure)
        {
            this.hubContext = hubContext;
            this.notificationProcedure = notificationProcedure;
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
            await hubContext.Clients.User(to).SendAsync("notification", new { description, redirectToUrl });
        }
    }
}
