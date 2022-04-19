using AdopPix.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace AdopPix.Pages.auth
{
    public class AuthenticatorLoginModel : PageModel
    {
        private readonly SignInManager<User> signInManager;

        public AuthenticatorLoginModel(SignInManager<User> signInManager)
        {
            authenticatorLoginViewModel = new AuthenticatorLoginViewModel();
            this.signInManager = signInManager;
        }

        [BindProperty]
        public AuthenticatorLoginViewModel authenticatorLoginViewModel { get; set; }

        public void OnGet(bool rememberMe)
        {
            authenticatorLoginViewModel.SecurityCode = string.Empty;
            authenticatorLoginViewModel.RememberMe = rememberMe;
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();
            var result = await signInManager.TwoFactorAuthenticatorSignInAsync(authenticatorLoginViewModel.SecurityCode,
                                                                               authenticatorLoginViewModel.RememberMe,
                                                                               false);
            if (result.Succeeded)
            {
                return Redirect("/");
            }
            else
            {
                ViewData["ErrorMessage"] = "Security code invalid.";
                return Page();
            }
        }
    }
    public class AuthenticatorLoginViewModel
    {
        [Required]
        public string SecurityCode { get; set; }
        public bool RememberMe { get; set; }
    }
}
