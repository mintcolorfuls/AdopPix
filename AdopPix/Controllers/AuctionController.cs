using AdopPix.Models;
using AdopPix.Models.ViewModels;
using AdopPix.Procedure.IProcedure;
using AdopPix.Services.IServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdopPix.Controllers
{
    public class AuctionController : Controller
    {
        private readonly INavbarService navbarService;
        private readonly IAuctionProcedure auctionProcedure;
        private readonly UserManager<User> userManager;
        private readonly IImageService imageService;
        private readonly IUserProfileProcedure userProfileProcedure;
        private string GenerateAuctionId()
        {
            string[] dateTime = DateTime.Now.ToString().Split(' ');
            string[] ddmmyyyy = dateTime[0].Split('/');
            string[] hhmmss = dateTime[1].Split(':');
            return $"auction-{string.Join("", ddmmyyyy)}{string.Join("", hhmmss)}";
        }
        public AuctionController(INavbarService navbarService, IUserProfileProcedure userProfileProcedure, UserManager<User> userManager, IAuctionProcedure auctionProcedure, IImageService imageService)
        {
            this.navbarService = navbarService;
            this.userManager = userManager;
            this.userProfileProcedure = userProfileProcedure;
            this.auctionProcedure = auctionProcedure;
            this.imageService = imageService;

        }
        //-----------------------------------------------------------------------------------------------------------
        public async Task<IActionResult> Index()
        {
            ViewData["NavbarDetail"] = await navbarService.FindByNameAsync(User.Identity.Name);


            var allAuctions = await auctionProcedure.GetAllAsync();
            var allAuctionImages = await auctionProcedure.GetAllImageAsync();
            ViewData["imageAuctions"] = allAuctionImages;


            return View(allAuctions);
        }

        //-----------------------------------------------------------------------------------------------------------
        public async Task<IActionResult> Create()
        {
            ViewData["NavbarDetail"] = await navbarService.FindByNameAsync(User.Identity.Name);
            return View();
        }
        //-----------------------------------------------------------------------------------------------------------


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




        //-----------------------------------------------------------------------------------------------------------

        [HttpGet("Auction/Post/{aucId}")]
        public async Task<IActionResult> AuctionPost(string aucId)
        {
            ViewData["NavbarDetail"] = await navbarService.FindByNameAsync(User.Identity.Name);
            //var user = await userManager.FindByNameAsync(auctionViewModel.AuctionId);
            var auctionpost = await auctionProcedure.FindByIdAsync(aucId);
            if(auctionpost == null)
            {
                return null;
            }
            var auctionimage = await auctionProcedure.FindImageByIdAsync(aucId);
            var userProfiles = await userProfileProcedure.FindByIdAsync(auctionpost.UserId);
            var users = await userManager.FindByIdAsync(auctionpost.UserId);
            var user = users.UserName;
            AuctionViewModel auction = new AuctionViewModel
            {
                AvaterName = userProfiles.AvatarName,
                UserName = user,
                AuctionId = auctionpost.AuctionId,
                UserId = auctionpost.UserId,
                Title = auctionpost.Title,
                HourId = auctionpost.HourId,
                OpeningPrice = auctionpost.OpeningPrice,
                HotClose = auctionpost.HotClose,
                Description = auctionpost.Description,
                Created = auctionpost.Created,
                ImageId = auctionimage.ImageId
            };




            return View(auction);
        }

        //-----------------------------------------------------------------------------------------------------------
       
        
        [HttpGet("/Auction/Edit/{postId}")]
        public async Task<IActionResult> Edit(string postId = "")
        {
            ViewData["NavbarDetail"] = await navbarService.FindByNameAsync(User.Identity.Name);

            var post = await auctionProcedure.FindByIdAsync(postId);
            if (post == null)
            {
                return null;
            }

            var image = await auctionProcedure.FindImageByIdAsync(postId);
            var userProfiles = await userProfileProcedure.FindByIdAsync(post.UserId);
            var users = await userManager.FindByIdAsync(post.UserId);
            AuctionViewModel edit = new AuctionViewModel
            {
                AvaterName = userProfiles.AvatarName,
                UserName = users.UserName,
                AuctionId = post.AuctionId,
                Title = post.Title,
                Description = post.Description,
                ImageId = image.ImageId
            };

            return View(edit);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(AuctionViewModel model)
        {
            ViewData["NavbarDetail"] = await navbarService.FindByNameAsync(User.Identity.Name);

            var auctiondetail = await auctionProcedure.FindByIdAsync(model.AuctionId);
            if (auctiondetail != null)
            {
                Auction auctionModel = new Auction()
                {
                    AuctionId = auctiondetail.AuctionId,
                    Title = model.Title,
                    Description = model.Description
                };
                await auctionProcedure.UpdateAuctionAsync(auctionModel);
                return RedirectToAction("Post", "Auction", new { id = auctiondetail.AuctionId });
            }
            return View(model);
        }


        //-----------------------------------------------------------------------------------------------------------

        [HttpGet("Auction/Delete/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            // หาว่าต้องลบโพสไหน
            var post = await auctionProcedure.FindByIdAsync(id);
            // หาว่าต้องลบภาพจากโพสไหน
            var postImage = await auctionProcedure.FindImageByIdAsync(id);
            // เช็คว่าเป็น null ไหม
            if (post == null)
            {
                return null;
            }
            // เช็คว่าเป็น null ไหม
            if (postImage == null)
            {
                return null;
            }

            // ลบภาพของโพสตามที่ตรวจเจอ
            await auctionProcedure.DeleteImageAsync(postImage);
            // ลบโพสตามที่ตรวจเจอ
            await auctionProcedure.DeleteAuctionAsync(post);


            return Redirect("/Auction");
        }


    }
}
