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
        private readonly INavbarService navbarService;

        public SettingModel(UserManager<User> userManager, INavbarService navbarService)
        {
            this.userManager = userManager;
            this.navbarService = navbarService;
            this.settingViewModel = new SettingViewModel();
        }

        [BindProperty]
        public SettingViewModel settingViewModel { get; set; }

        public async Task OnGetAsync()
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name);

            if(user != null)
            {
                settingViewModel.EnableTwoFactor = await userManager.GetTwoFactorEnabledAsync(user);
            }
            ViewData["NavbarDetail"] = await navbarService.FindByNameAsync(User.Identity.Name);
        }
    }
    public class SettingViewModel
    {
        public bool EnableTwoFactor { get; set; }
    }
   
}
