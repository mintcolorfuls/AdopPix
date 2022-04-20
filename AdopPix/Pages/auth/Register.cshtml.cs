using AdopPix.DataAccess.Core.IConfiguration;
using AdopPix.DataAccess.Core.IRepository;
using AdopPix.Models;
using AdopPix.Services.IServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace AdopPix.Pages.auth
{
    public class RegisterModel : PageModel
    {
        private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IUnitOfWork unitOfWork;
        private readonly IEmailService emailService;

        public RegisterModel(UserManager<User> userManager,
                             RoleManager<IdentityRole> roleManager,
                             IUnitOfWork unitOfWork,
                             IEmailService emailService)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.unitOfWork = unitOfWork;
            this.emailService = emailService;
        }
        [BindProperty]
        public RegisterViewModel registerViewModel { get; set; }
        [BindProperty]
        public bool GoConfirmEmail { get; set; }

        public IActionResult OnGet()
        {
            GoConfirmEmail = false;
            if (User.Identity.IsAuthenticated)
            {
                return Redirect("/");
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if(!ModelState.IsValid) return Page();

            bool stateError = false;

            if(!registerViewModel.Agree)
            {
                ModelState.AddModelError("registerViewModel.Agree", "please accept term of use.");
                stateError = true;
            }
            if(registerViewModel.BirthDay == null)
            {
                ModelState.AddModelError("registerViewModel.BirthDay", "please enter your birthday");
                stateError = true;
            }

            if(stateError)
            {
                return Page();
            }

            var existUser = await userManager.FindByEmailAsync(registerViewModel.Email);

            if (existUser != null)
            {
                if (existUser.Email == registerViewModel.Email)
                {
                    ModelState.AddModelError("registerViewModel.Email", "Email is aleady to use.");
                }
                if (existUser.UserName == registerViewModel.AdopPixId)
                {
                    ModelState.AddModelError("registerViewModel.AdopPixId", "AdopPixId is aleady to use.");
                }
                return Page();
            }
           
            User user = new User
            {
                Email = registerViewModel.Email,
                UserName = registerViewModel.AdopPixId, 
            };
            
            var userCreate = await userManager.CreateAsync(user, registerViewModel.Password);

            if(userCreate.Succeeded)
            {
                user = await userManager.FindByEmailAsync(registerViewModel.Email);

                if(!await roleManager.RoleExistsAsync("member"))
                {
                    await roleManager.CreateAsync(new IdentityRole { Name = "member" });
                }

                await userManager.AddToRoleAsync(user, "member");

                string confirmationToken = await userManager.GenerateEmailConfirmationTokenAsync(user);
                string confirmationLink = Url.PageLink(pageName: "/auth/ConfirmEmail",
                                                       values: new { userId = user.Id, token = confirmationToken });
                string template = emailService.CreateTemplate("ConfirmEmail");
                string content = emailService.SetupConfirmEmailTemplate(template, confirmationLink);

                await emailService.SendAsync("AdopPix <account@adoppix.com>", user.Email, "Confirm your email.", content);

                UserProfile profile = new UserProfile
                {
                    UserId = user.Id,
                    Gender = registerViewModel.Gender.ToString(),
                    AvaterName = "AvatarNopic.png",
                    CoverName = "",
                    Fname = "",
                    Lname = "",
                    Money = 0,
                    BirthDate = (DateTime)registerViewModel.BirthDay,
                    Point = 0,
                    Rank = 0,
                    Created = DateTime.Now,
                };
                var profileCreate = await unitOfWork.UserProfile.CreateAsync(profile);
                await unitOfWork.CompleateAsync();

                if(profileCreate)
                {
                    GoConfirmEmail = true;
                    return Page();
                }
            }
            return Page();
        }

    }
    public class RegisterViewModel
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Must be between 5 and 100 characters.")]
        public string Password { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Must be between 5 and 100 characters.")]
        [Compare("Password", ErrorMessage = "Password do not match.")]
        public string ConfirmPassword { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Must be between 5 and 100 characters.")]
        public string AdopPixId { get; set; }
        [Required]
        public Gender Gender { get; set; }
        public DateTime? BirthDay { get; set; } = DateTime.Now;
        public bool Agree { get; set; }
    }
    public enum Gender
    {
        Male,
        Female
    }
}
