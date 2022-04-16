using Microsoft.AspNetCore.Http;

namespace AdopPix.Models.ViewModels
{
    public class AccountSettingViewModel
    {
        public string AvaterName { get; set; }
        public string CoverName { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Description { get; set; }
        public string Gender { get; set; }

        public IFormFile AvatarFile { get; set; }
        public IFormFile CoverFile { get; set; }
    }
}
