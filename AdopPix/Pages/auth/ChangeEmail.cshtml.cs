using AdopPix.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AdopPix.Pages.auth
{
    public class ChangeEmailModel : PageModel
    {
        private readonly UserManager<User> userManager;

        public ChangeEmailModel(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }
        public void OnGet()
        {
        }
    }
}
