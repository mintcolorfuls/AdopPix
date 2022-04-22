using AdopPix.DataAccess.Core.IConfiguration;
using AdopPix.Models;
using AdopPix.Models.ViewModels;
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
        private readonly IUnitOfWork unitOfWork;
        private readonly UserManager<User> userManager;
        private readonly IImageService imageService;

        public AccountController(IUnitOfWork unitOfWork,
                                 UserManager<User> userManager,
                                 IImageService imageService)
        {
            this.unitOfWork = unitOfWork;
            this.userManager = userManager;
            this.imageService = imageService;
        }
        [HttpGet("{id}")]
        public IActionResult Index(string id)
        {
            return View();
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> Setting()
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            var userProfile = await unitOfWork.UserProfile.GetByIdAsync(user.Id);

            Dictionary<int, string> socialTypes = new Dictionary<int, string>();
            socialTypes = unitOfWork.SocialMediaType.GetAllAsync().Result.ToDictionary(f => f.SocialId, f => f.Title);
            var userSocials = await unitOfWork.SocialMedia.GetAllAsync();

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

            AccountSettingViewModel accountSettingViewModel = new AccountSettingViewModel
            {
                AvaterName = userProfile.AvaterName,
                CoverName = userProfile.CoverName,
                Description = userProfile.Description,
                Fname = userProfile.Fname,
                Lname = userProfile.Lname,
                Gender = userProfile.Gender,
            };

            if (TempData["AddSocialError"] != null)
            {
                ViewBag.AddSocialError = TempData["AddSocialError"].ToString();
            }

            return View(accountSettingViewModel);
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> Setting(AccountSettingViewModel accountSettingViewModel)
        {
            if(!ModelState.IsValid) return View(accountSettingViewModel);

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
            var userProfile = await unitOfWork.UserProfile.GetByIdAsync(user.Id);



            userProfile.AvaterName = avatarName;
            userProfile.CoverName = coverName;
            userProfile.Fname = accountSettingViewModel.Fname;
            userProfile.Lname = accountSettingViewModel.Lname;
            userProfile.Description = accountSettingViewModel.Description;

            unitOfWork.UserProfile.Update(userProfile);
            await unitOfWork.CompleateAsync();

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
                var userSocial = await unitOfWork.SocialMedia.GetByUrlAsync(url);
                if(userManager != null)
                {
                    TempData["AddSocialError"] = "Url already used.";
                    return RedirectToAction(nameof(Setting));
                }

                string[] urlSplit = url.Split('/', StringSplitOptions.RemoveEmptyEntries);
                if(urlSplit.Length <= 3)
                {
                    string[] domainSplit = urlSplit[1].Split(new string[] { "www", ".", "com", "net" }, StringSplitOptions.RemoveEmptyEntries);
                    
                    var type = await unitOfWork.SocialMediaType.GetByNameAsync(domainSplit[0]);
                    if (type != null)
                    {
                        SocialMedia socialMedia = new SocialMedia
                        {
                            SocialId = type.SocialId,
                            Url = url,
                            Created = DateTime.Now,
                            UserId = user.Id,
                        };

                        await unitOfWork.SocialMedia.CreateAsync(socialMedia);
                        await unitOfWork.CompleateAsync();
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
    }
}
