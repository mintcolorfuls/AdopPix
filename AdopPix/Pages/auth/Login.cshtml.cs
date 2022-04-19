using AdopPix.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace AdopPix.Pages.auth
{
    public class LoginModel : PageModel
    {
        private readonly SignInManager<User> signInManager;
        private readonly UserManager<User> userManager;

        public LoginModel(SignInManager<User> signInManager,
                          UserManager<User> userManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
        }

        [BindProperty]
        public LoginViewModel loginViewModel { get; set; }

        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if(!ModelState.IsValid) return Page();

            var user = await userManager.FindByEmailAsync(loginViewModel.Email);

            if(user == null)
            {
                ModelState.AddModelError("loginViewModel.Email", "The specified user account could not be found.");
                return Page();
            }
            if(!await userManager.CheckPasswordAsync(user, loginViewModel.Password))
            {
                ModelState.AddModelError("loginViewModel.Password", "Password invalid.");
                return Page();
            }

            var resultLogin = await signInManager.PasswordSignInAsync(user.UserName, 
                                                                      loginViewModel.Password, 
                                                                      loginViewModel.RememberMe, 
                                                                      false);

            if(resultLogin.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                if(await userManager.IsEmailConfirmedAsync(user))
                {
                    ViewData["ErrorMessage"] = "Please confirm your email.";
                    return Page();
                }
                if(resultLogin.RequiresTwoFactor)
                {
                    return RedirectToPage("/Account/LoginTwoFactorWithAuthenticator", new { RememberMe = loginViewModel.RememberMe });
                }
                return Page();
            }
        }
    }
    public class LoginViewModel
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
