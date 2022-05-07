using AdopPix.Models;
using AdopPix.Models.ViewModels;
using AdopPix.Procedure.IProcedure;
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
        private readonly INotificationService notificationService;
        private readonly UserManager<User> userManager;
        private readonly INavbarService navbarService;

        public HomeController(INotificationService notificationService,
                              UserManager<User> userManager,
                              INavbarService navbarService)
        {
            this.notificationService = notificationService;
            this.userManager = userManager;
            this.navbarService = navbarService;
        }

        public async Task<IActionResult> Index()
        {
            ViewData["NavbarDetail"] = await navbarService.FindByNameAsync(User.Identity.Name);
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(string UserId, string Description, string RedirectToUrl)
        {
            ViewData["NavbarDetail"] = await navbarService.FindByNameAsync(User.Identity.Name);
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            await notificationService.NotificationByUserIdAsync(user.Id, UserId, Description, RedirectToUrl);
            return View();
        }

        public async Task<IActionResult> Privacy()
        {
            ViewData["NavbarDetail"] = await navbarService.FindByNameAsync(User.Identity.Name);
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
