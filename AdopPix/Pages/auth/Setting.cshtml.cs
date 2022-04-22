using AdopPix.Models;
using AdopPix.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace AdopPix.Pages.auth
{
    [Authorize]
    public class SettingModel : PageModel
    {
        private readonly UserManager<User> userManager;

        public SettingModel(UserManager<User> userManager)
        {
            this.userManager = userManager;
            this.settingViewModel = new SettingViewModel();
        }

        [BindProperty]
        public SettingViewModel settingViewModel { get; set; }

        public async Task OnGet()
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name);

            if(user != null)
            {
                settingViewModel.EnableTwoFactor = await userManager.GetTwoFactorEnabledAsync(user);
            }

        }
    }
    public class SettingViewModel
    {
        public bool EnableTwoFactor { get; set; }
    }
   
}
