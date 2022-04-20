using AdopPix.Models;
using AdopPix.Services.IServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace AdopPix.Pages.auth
{
    public class ForgetPasswordModel : PageModel
    {
        private readonly UserManager<User> userManager;
        private readonly IEmailService emailService;

        public ForgetPasswordModel(UserManager<User> userManager,
                                   IEmailService emailService)
        {
            this.userManager = userManager;
            this.emailService = emailService;
        }

        [BindProperty]
        public ForgetPasswordViewModel forgetPasswordViewModel { get; set; }
        [BindProperty]
        public bool Succeeded { get; set; }

        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if(!ModelState.IsValid) return Page();
            var user = await userManager.FindByEmailAsync(forgetPasswordViewModel.Email);
            if (user != null)
            {
                string token = await userManager.GeneratePasswordResetTokenAsync(user);
                string template = emailService.CreateTemplate("ForgetPassword");

                var url = Url.PageLink(pageName: "/auth/ResetPassword", values: new { userId = user.Id, token = token});
                string content = emailService.SetupForgetPasswordTemplate(template, url);
                await emailService.SendAsync("AdopPix <account@adoppix.com>", user.Email, "Reset password", content);
                Succeeded = true;
                return Page();
            }
            else
            {
                ModelState.AddModelError("forgetPasswordViewModel.Email", "The specified user account could not be found.");
                return Page();
            }
        }
    }
    public class ForgetPasswordViewModel
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
