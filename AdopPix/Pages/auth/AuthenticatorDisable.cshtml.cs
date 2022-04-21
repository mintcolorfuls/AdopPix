using AdopPix.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace AdopPix.Pages.auth
{
    [Authorize]
    public class AuthenticatorDisableModel : PageModel
    {
        private readonly UserManager<User> userManager;

        public AuthenticatorDisableModel(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }

        [BindProperty]
        public AuthenticatorDisableViewModel authenticatorDisableViewModel { get; set; }
        [BindProperty]
        public bool Succeeded { get; set; }

        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync()
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name);

            if (user != null)
            {
                var resultVerify = await userManager.VerifyTwoFactorTokenAsync(user,
                                                                               userManager.Options.Tokens.AuthenticatorTokenProvider,
                                                                               authenticatorDisableViewModel.SecurityCode);
                if(resultVerify)
                {
                    await userManager.SetTwoFactorEnabledAsync(user, false);
                    Succeeded = true;
                }
                else
                {
                    ViewData["ErrorMessage"] = "Security code invalid.";
                }
            }
            else
            {
                return RedirectToPage(pageName: "/auth/login");
            }
            return Page();
        }

    }
    public class AuthenticatorDisableViewModel
    {
        [Required]
        public string SecurityCode { get; set; }
    }
}
