using AdopPix.Models;
using AdopPix.Services.IServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace AdopPix.Pages.auth
{
    public class ChangeEmailModel : PageModel
    {
        private readonly UserManager<User> userManager;
        private readonly IEmailService emailService;

        public ChangeEmailModel(UserManager<User> userManager,
                                IEmailService emailService)
        {
            this.userManager = userManager;
            this.emailService = emailService;
        }

        [BindProperty]
        public ChangeEmailViewModel changeEmailViewModel { get; set; }
        [BindProperty]
        public bool isSend { get; set; }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if(!ModelState.IsValid) return Page();

            var user = await userManager.FindByEmailAsync(changeEmailViewModel.Email);
            if(user != null)
            {
                ModelState.AddModelError("changeEmailViewModel.Email", "Email is already in use.");
                return Page();
            }
            
            user = await userManager.FindByNameAsync(User.Identity.Name);
            if (user != null)
            {
                var token = await userManager.GenerateChangeEmailTokenAsync(user, changeEmailViewModel.Email);
                var link = Url.PageLink(pageName: "/auth/ConfirmChangeEmail",
                    values: new { userId = user.Id, email = changeEmailViewModel.Email, token = token });

                string template = emailService.CreateTemplate("ChangeEmail");
                string content = template.Replace("[url]", link);
                await emailService.SendAsync("AdopPix <account@adoppix.com>", user.Email, "Change Email", content);
            }
            isSend = true;
            return Page();
        }
    }
    public class ChangeEmailViewModel
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
