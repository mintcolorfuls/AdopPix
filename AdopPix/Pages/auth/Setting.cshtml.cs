using AdopPix.Models;
using AdopPix.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AdopPix.Pages.auth
{
    [Authorize]
    public class SettingModel : PageModel
    {
        private readonly UserManager<User> userManager;
        private readonly IEmailService emailService;

        public SettingModel(UserManager<User> userManager,
                            IEmailService emailService)
        {
            this.userManager = userManager;
            this.emailService = emailService;
        }
        public void OnGet()
        {
        }
        public IActionResult OnPostChangeEmail()
        {
            return Redirect("/");
        }
    }
}
