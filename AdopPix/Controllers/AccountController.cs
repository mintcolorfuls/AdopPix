using AdopPix.DataAccess.Core.IConfiguration;
using AdopPix.Models;
using AdopPix.Models.ViewModels;
using AdopPix.Procedure.IProcedure;
using AdopPix.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdopPix.Controllers
{
    [Authorize]
    [Route("[controller]")]
    public class AccountController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly IImageService imageService;
        private readonly IUserProfileProcedure userProfileProcedure;
        private readonly ISocialMediaProcedure socialMediaProcedure;
        private readonly ISocialMediaTypeProcedure socialMediaTypeProcedure;
        private readonly INavbarService navbarService;

        public AccountController(UserManager<User> userManager,
                                 IImageService imageService,
                                 IUserProfileProcedure userProfileProcedure,
                                 ISocialMediaProcedure socialMediaProcedure,
                                 ISocialMediaTypeProcedure socialMediaTypeProcedure,
                                 INavbarService navbarService)
        {
            this.userManager = userManager;
            this.imageService = imageService;
            this.userProfileProcedure = userProfileProcedure;
            this.socialMediaProcedure = socialMediaProcedure;
            this.socialMediaTypeProcedure = socialMediaTypeProcedure;
            this.navbarService = navbarService;
        }
        [HttpGet("{id}")]
        public IActionResult Index(string id)
        {
            return View();
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> Setting()
        {
            ViewData["NavbarDetail"] = await navbarService.FindByNameAsync(User.Identity.Name);

            var user = await userManager.FindByNameAsync(User.Identity.Name);
            var userProfile = await userProfileProcedure.FindByIdAsync(user.Id);
            AccountSettingViewModel accountSettingViewModel = new AccountSettingViewModel
            {
                AvaterName = userProfile.AvatarName,
                CoverName = userProfile.CoverName,
                Description = userProfile.Description,
                Fname = userProfile.Fname,
                Lname = userProfile.Lname,
                Gender = userProfile.Gender,
            };

            Dictionary<int, string> socialTypes = await socialMediaTypeProcedure.FindAsync();
            var userSocials = await socialMediaProcedure.FindByIdAsync(user.Id);
            List<UserSocialViewModel> userSocial = new List<UserSocialViewModel>();
            foreach (var social in userSocials)
            {
                UserSocialViewModel socialMediaResponse = new UserSocialViewModel
                {
                    Url = social.Url,
                    Title = socialTypes[social.SocialId]
                };
                userSocial.Add(socialMediaResponse);
            }
            ViewData["UserSocials"] = userSocial;

            if (TempData["AddSocialError"] != null)
            {
                ViewBag.AddSocialError = TempData["AddSocialError"].ToString();
            }

            return View(accountSettingViewModel);
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> Setting(AccountSettingViewModel accountSettingViewModel)
        {
            
            ViewData["NavbarDetail"] = await navbarService.FindByNameAsync(User.Identity.Name);

            if (!ModelState.IsValid) return View(accountSettingViewModel);

            string avatarName = accountSettingViewModel.AvaterName;
            string coverName = accountSettingViewModel.CoverName;

            if(accountSettingViewModel.AvatarFile != null)
            {
                string[] extension = { ".png", ".jpg" };
                if(imageService.ValidateExtension(extension, accountSettingViewModel.AvatarFile))
                {
                    avatarName = await imageService.UploadImageAsync(accountSettingViewModel.AvatarFile);
                }
                else
                {
                    ModelState.AddModelError("AvatarFile", "We support .png, .jpg");
                    return View(accountSettingViewModel);
                }
            }
            if (accountSettingViewModel.CoverFile != null)
            {
                string[] extension = { ".png", ".jpg" };
                if (imageService.ValidateExtension(extension, accountSettingViewModel.CoverFile))
                {
                    coverName = await imageService.UploadImageAsync(accountSettingViewModel.CoverFile);
                }
                else
                {
                    ModelState.AddModelError("CoverFile", "We support .png, .jpg");
                    return View(accountSettingViewModel);
                }
            }

            var user = await userManager.FindByNameAsync(User.Identity.Name);
            var userProfile = await userProfileProcedure.FindByIdAsync(user.Id);

            userProfile.AvatarName = avatarName;
            userProfile.CoverName = coverName;
            userProfile.Fname = accountSettingViewModel.Fname;
            userProfile.Lname = accountSettingViewModel.Lname;
            userProfile.Description = accountSettingViewModel.Description;

            await userProfileProcedure.UpdateAsync(userProfile);

            return Redirect("/Account/Setting");
        }
     
        [HttpPost("[action]")]
        public async Task<IActionResult> AddSocial(string url)
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            if(user == null)
            {
                return BadRequest();
            }

            if(!string.IsNullOrEmpty(url))
            {
                var userSocial = await socialMediaProcedure.FindByUrlAsync(user.Id, url);
                if(userSocial != null)
                {
                    TempData["AddSocialError"] = "Url already used.";
                    return RedirectToAction(nameof(Setting));
                }

                string[] urlSplit = url.Split('/', StringSplitOptions.RemoveEmptyEntries);
                if(urlSplit.Length <= 3)
                {
                    string[] domainSplit = urlSplit[1].Split(new string[] { "www", ".", "com", "net" }, StringSplitOptions.RemoveEmptyEntries);
                    
                    var type = await socialMediaTypeProcedure.FindByNameAsync(domainSplit[0]);
                    if (type != null)
                    {
                        SocialMedia socialMedia = new SocialMedia
                        {
                            SocialId = type.SocialId,
                            Url = url,
                            Created = DateTime.Now,
                            UserId = user.Id,
                        };
                        await socialMediaProcedure.CreateAsync(socialMedia);
                    }
                    else
                    {
                        TempData["AddSocialError"] = "We don't support this social media, we support facebook, instagram, github.";
                    }
                }
                else
                {
                    TempData["AddSocialError"] = "Url invalid.";
                }
            }
            else
            {
                TempData["AddSocialError"] = "Please enter your social url.";
            }
            return RedirectToAction(nameof(Setting));
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> DeleteSocial(string url)
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            if (user == null) return BadRequest();

            var userSocial = await socialMediaProcedure.FindByUrlAsync(user.Id, url);
            if (userSocial == null) return BadRequest();

            await socialMediaProcedure.DeleteAsync(userSocial);

            return RedirectToAction(nameof(Setting));
        }
    }
}
