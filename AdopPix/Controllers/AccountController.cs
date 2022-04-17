using AdopPix.DataAccess.Core.IConfiguration;
using AdopPix.Models;
using AdopPix.Models.ViewModels;
using AdopPix.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
            AccountSettingViewModel accountSettingViewModel = new AccountSettingViewModel
            {
                AvaterName = userProfile.AvaterName,
                CoverName = userProfile.CoverName,
                Description = userProfile.Description,
                Fname = userProfile.Fname,
                Lname = userProfile.Lname,
                Gender = userProfile.Gender,
            };

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
    }
}
