﻿using AdopPix.Models;
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
        private readonly IImageService imageService;

        private string GenerateAuctionId()
        {
            string[] dateTime = DateTime.Now.ToString().Split(' ');
            string[] ddmmyyyy = dateTime[0].Split('/');
            string[] hhmmss = dateTime[1].Split(':');
            return $"auction-{string.Join("", ddmmyyyy)}{string.Join("", hhmmss)}";
        }

        public AuctionController( INavbarService navbarService, UserManager<User> userManager , IAuctionProcedure auctionProcedure, IImageService imageService)
        {
            this.navbarService = navbarService;
            this.userManager = userManager;
            this.auctionProcedure = auctionProcedure;
            this.imageService = imageService;    
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
            string imageAuctionName = auctionViewModel.AuctionImage;

            if (auctionViewModel.AuctionFile != null)
            {
                string[] extension = { ".png", ".jpg" };
                if (imageService.ValidateExtension(extension, auctionViewModel.AuctionFile))
                {
                    imageAuctionName = await imageService.UploadAuctionImageAsync(auctionViewModel.AuctionFile);
                }
                else
                {
                    ModelState.AddModelError("AvatarFile", "We support .png, .jpg");
                    return View(auctionViewModel);
                }
            }


            var generateAuctionId = GenerateAuctionId();
            Auction auction = new Auction
            {
                AuctionId = generateAuctionId,
                UserId = user.Id,
                Title = auctionViewModel.Title,
                HourId = auctionViewModel.HourId,
                OpeningPrice = auctionViewModel.OpeningPrice,
                HotClose = auctionViewModel.HotClose,
                Description = auctionViewModel.Description,
                Created = DateTime.Now,

            };
            await auctionProcedure.CreateAsync(auction);
            AuctionImage auctionImage = new AuctionImage
            {
                AuctionId = generateAuctionId,
                ImageId = imageAuctionName,
                ImageTypeId = auctionViewModel.ImageTypeId,
                Created = auctionViewModel.Created,
            };
            await auctionProcedure.CreateImageAsync(auctionImage);

            return Redirect("/Auction");
        }





        [HttpGet("Auction/Post/{auctionpost.AuctionId}")]
        public async Task<IActionResult> AuctionPost(AuctionViewModel auctionViewModel)
        {
            ViewData["NavbarDetail"] = await navbarService.FindByNameAsync(User.Identity.Name);
            //var user = await userManager.FindByNameAsync(auctionViewModel.AuctionId);
            var auctionpost = await auctionProcedure.FindByIdAsync(auctionViewModel.AuctionId);
            AuctionViewModel auction = new AuctionViewModel
            {
                AuctionId = auctionpost.AuctionId,
                UserId = auctionpost.UserId,
                Title = auctionpost.Title,
                HourId = auctionpost.HourId,
                OpeningPrice = auctionpost.OpeningPrice,
                HotClose = auctionpost.HotClose,
                Description = auctionpost.Description,
                Created = auctionpost.Created,
            };



            return View(auction);
        }
    }
}
