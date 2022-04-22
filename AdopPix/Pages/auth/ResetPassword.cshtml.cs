using AdopPix.Models;
using AdopPix.Services.IServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace AdopPix.Pages.auth
{
    public class ResetPasswordModel : PageModel
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;

        public ResetPasswordModel(UserManager<User> userManager,
                                   SignInManager<User> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.resetPasswordViewModel = new ResetPasswordViewModel();
        }

        [BindProperty]
        public ResetPasswordViewModel resetPasswordViewModel { get; set; }
        [BindProperty]
        public bool Succeeded { get; set; }
        public async Task<IActionResult> OnGetAsync(string userId, string token)
        {
            if(User.Identity.IsAuthenticated)
            {
                await signInManager.SignOutAsync();
                return Redirect("/auth/login");
            }
            resetPasswordViewModel.userId = userId;
            resetPasswordViewModel.token = token;
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            if (string.IsNullOrEmpty(resetPasswordViewModel.userId) || string.IsNullOrEmpty(resetPasswordViewModel.token)) return BadRequest();
            var user = await userManager.FindByIdAsync(resetPasswordViewModel.userId);
            if (user != null)
            {
                var result = await userManager.ResetPasswordAsync(user, resetPasswordViewModel.token, resetPasswordViewModel.Password);
                if (result.Succeeded)
                {
                    Succeeded = true;
                }
                else
                {
                    ViewData["ErrorMessage"] = "Token invalid";
                }
            }
            return Page();
        }
    }
    public class ResetPasswordViewModel
    {
        public string userId { get; set; }
        public string token { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Must be between 5 and 100 characters.")]
        public string Password { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Must be between 5 and 100 characters.")]
        [Compare("Password", ErrorMessage = "Password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
