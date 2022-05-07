using AdopPix.Models;
using AdopPix.Models.ViewModels;
using AdopPix.Procedure.IProcedure;
using AdopPix.Services.IServices;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdopPix.Services
{
    public class NavbarService : INavbarService
    {
        private readonly UserManager<User> userManager;
        private readonly IUserProfileProcedure userProfileProcedure;
        private readonly INotificationProcedure notificationProcedure;

        public NavbarService(UserManager<User> userManager,
                             IUserProfileProcedure userProfileProcedure,
                             INotificationProcedure notificationProcedure)
        {
            this.userManager = userManager;
            this.userProfileProcedure = userProfileProcedure;
            this.notificationProcedure = notificationProcedure;
        }
        public async Task<NavbarViewModel> FindByNameAsync(string username)
        {
            var user = await userManager.FindByNameAsync(username);
            var userProfile = await userProfileProcedure.FindByIdAsync(user.Id);
            var notifications = await notificationProcedure.FindByUserIdAsync(user.Id);

            NavbarViewModel navbarViewModel = new NavbarViewModel();
            navbarViewModel.AvatarName = userProfile.AvatarName;

            List<NotificationViewModel> notificationViewModels = new List<NotificationViewModel>();
            if (notifications.Count > 0)
            {
                foreach (var notification in notifications)
                {
                    var userFrom = await userManager.FindByIdAsync(notification.From);
                    var userProfileFrom = await userProfileProcedure.FindByIdAsync(notification.From);

                    NotificationViewModel notificationViewModel = new NotificationViewModel
                    {
                        AvatarName = userProfileFrom.AvatarName,
                        UserName = userFrom.UserName,
                        Description = notification.Description,
                        RedirectToUrl = notification.RedirectToUrl,
                        Created = notification.Created,
                    };
                    notificationViewModels.Add(notificationViewModel);
                }
            }

            navbarViewModel.Notifications = notificationViewModels;
            return navbarViewModel;
        }
    }
}
