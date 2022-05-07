using System.Collections.Generic;

namespace AdopPix.Models.ViewModels
{
    public class NavbarViewModel
    {
        public string AvatarName { get; set; }
        public List<NotificationViewModel> Notifications { get; set; }
    }
}
