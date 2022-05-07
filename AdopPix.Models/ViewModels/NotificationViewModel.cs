using System;

namespace AdopPix.Models.ViewModels
{
    public class NotificationViewModel
    {
        public string AvatarName { get; set; }
        public string UserName { get; set; }
        public string Description { get; set; }
        public string RedirectToUrl { get; set; }
        public DateTime Created { get; set; }
    }
}
