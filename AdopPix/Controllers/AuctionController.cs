using AdopPix.Models;
using AdopPix.Models.ViewModels;
using AdopPix.Procedure.IProcedure;
using AdopPix.Services.IServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AdopPix.Controllers
{
    public class AuctionController : Controller
    {
        private readonly INavbarService navbarService;
        private readonly IAuctionProcedure auctionProcedure;
        private readonly UserManager<User> userManager;


        public AuctionController( INavbarService navbarService, UserManager<User> userManager , IAuctionProcedure auctionProcedure)
        {
            this.navbarService = navbarService;
            this.userManager = userManager;
            this.auctionProcedure = auctionProcedure;
        }

        public async Task<IActionResult> Index()
        {
            ViewData["NavbarDetail"] = await navbarService.FindByNameAsync(User.Identity.Name);
            return View();
        }
        public async Task<IActionResult> Create()
        {
            ViewData["NavbarDetail"] = await navbarService.FindByNameAsync(User.Identity.Name);
            return View();
        }


        [HttpPost("Auction/Create")]

        public async Task<IActionResult> Create(AuctionViewModel auctionViewModel)
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            ViewData["NavbarDetail"] = await navbarService.FindByNameAsync(User.Identity.Name);
            Auction auction = new Auction
            {
                UserId = user.Id,
                Title = auctionViewModel.Title,
                HourId = auctionViewModel.HourId,
                OpeningPrice = auctionViewModel.OpeningPrice,
                HotClose = auctionViewModel.HotClose,
                Description = auctionViewModel.Description,
                Created = DateTime.Now,
            };
            await auctionProcedure.CreateAsync(auction);


            return Redirect("/Auction");
        }
    }
}
