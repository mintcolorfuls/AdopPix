using AdopPix.Models;
using AdopPix.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AdopPix.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IImageService imageService;
        private readonly INotificationService notificationService;
        private readonly UserManager<User> userManager;

        public HomeController(ILogger<HomeController> logger, 
                              IImageService imageService, 
                              INotificationService notificationService,
                              UserManager<User> userManager)
        {
            _logger = logger;
            this.imageService = imageService;
            this.notificationService = notificationService;
            this.userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(string UserId, string Description, string RedirectToUrl)
        {
            //string[] extension = { ".png", ".jpg" };
            //if(imageService.ValidateExtension(extension, file))
            //{
            //    ViewBag.Name = await imageService.UploadImageAsync(file);
            //    ViewBag.Succeeded = imageService.Succeeded;
            //}
            //else
            //{
            //    ViewBag.Succeeded = false;
            //}

            var user = await userManager.FindByNameAsync(User.Identity.Name);
            await notificationService.NotificationByUserIdAsync(user.Id, UserId, Description, RedirectToUrl);
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
