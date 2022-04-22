using AdopPix.Models;
using AdopPix.Services.IServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace AdopPix.Pages.auth
{
    public class ConfirmChangeEmailModel : PageModel
    {
        private readonly UserManager<User> userManager;
        private readonly IEmailService emailService;

        public ConfirmChangeEmailModel(UserManager<User> userManager,
                                       IEmailService emailService)
        {
            this.userManager = userManager;
            this.emailService = emailService;
        }
        public async Task<IActionResult> OnGetAsync(string userId, string email, string token)
        {
            if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(token)) return BadRequest();
            var user = await userManager.FindByIdAsync(userId);
            if(user != null)
            {
                var result = await userManager.ChangeEmailAsync(user, email, token);
                if (result.Succeeded)
                {
                    user.EmailConfirmed = false;
                    var resultUpdate = await userManager.UpdateAsync(user);

                    if(resultUpdate.Succeeded)
                    {
                        string confirmationToken = await userManager.GenerateEmailConfirmationTokenAsync(user);
                        string confirmationLink = Url.PageLink(pageName: "/auth/ConfirmEmail",
                                                               values: new { userId = user.Id, token = confirmationToken });
                        string template = emailService.CreateTemplate("ConfirmEmail");
                        string content = emailService.SetupConfirmEmailTemplate(template, confirmationLink);

                        await emailService.SendAsync("AdopPix <account@adoppix.com>", user.Email, "Confirm your email.", content);
                    }
                }
            }
            return Page();
        }
    }
}
