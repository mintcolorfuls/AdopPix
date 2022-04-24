using AdopPix.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace AdopPix.Pages.auth
{
    public class ConfirmEmailModel : PageModel
    {
        private readonly UserManager<User> userManager;

        public ConfirmEmailModel(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }

        [BindProperty]
        public string Message { get; set; }
        [BindProperty]
        public bool Status { get; set; }

        public async Task<IActionResult> OnGetAsync(string userId, string token)
        {
            var user = await userManager.FindByIdAsync(userId);
            if (user != null)
            {
                var result = await userManager.ConfirmEmailAsync(user, token);

                if (result.Succeeded)
                {
                    Status = true;
                    Message = "Your email has been verified. Have fun with the auction!";
                    return Page();  
                }
                Status = false;
                Message = "token invalid, Please contact customer support at account@adoppix.com";
                return Page();
            }
            Status = false;
            Message = "user invalid, Please contact customer support at account@adoppix.com";
            return Page();
        }
    }
}
