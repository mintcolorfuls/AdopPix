using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdopPix.Services.IServices
{
    public interface INotificationService
    {
        Task NotificationByUserId(string userId);
    }
}
