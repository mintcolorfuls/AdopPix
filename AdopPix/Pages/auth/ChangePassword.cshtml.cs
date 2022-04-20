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
    public class ChangePasswordModel : PageModel
    {
        private readonly UserManager<User> userManager;

        public ChangePasswordModel(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }
        [BindProperty]
        public ChangePasswordViewModel changePasswordViewModel { get; set; }
        [BindProperty]
        public bool isSucceeded { get; set; }

        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost()
        {
            if(!ModelState.IsValid) return Page();

            var user = await userManager.FindByNameAsync(User.Identity.Name);

            var changeResult = await userManager.ChangePasswordAsync(user, changePasswordViewModel.OldPassword, changePasswordViewModel.NewPassword);
            if(changeResult.Succeeded)
            {
                isSucceeded = true;
                return Page();
            }
            else
            {
                if(!await userManager.CheckPasswordAsync(user, changePasswordViewModel.OldPassword))
                {
                    ModelState.AddModelError("changePasswordViewModel.OldPassword", "Password invalid.");
                }
                return Page();
            }
        
        }
    }
    public class ChangePasswordViewModel
    {
        [Required]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Must be between 5 and 100 characters.")]
        public string OldPassword { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Must be between 5 and 100 characters.")]
        public string NewPassword { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Must be between 5 and 100 characters.")]
        [Compare("NewPassword", ErrorMessage = "Password do not match.")]
        public string ConfirmNewPassword { get; set; }
    }
}
