using AdopPix.Models;
using AdopPix.Models.ViewModels;
using AdopPix.Procedure;
using AdopPix.Procedure.IProcedure;
using AdopPix.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdopPix.Controllers
{
    [Authorize]
    public class PostController : Controller
    {
        private readonly INavbarService navbarService;
        private readonly IPostProcedure post;
        private readonly UserManager<User> userManager;
        private readonly IImageService imageService;

        public PostController(IPostProcedure post,
                              INavbarService navbarService,
                              UserManager<User> userManager, 
                              IImageService imageService)
        {
            this.post = post;
            this.navbarService = navbarService;
            this.userManager = userManager;
            this.imageService = imageService;
        }
        
        [HttpPost]
        public async Task<IActionResult> Create(string Title, string Description,IFormFile Image)
        {
            string[] extension = { ".png", ".jpg" };
            string fileName = string.Empty;
            if (imageService.ValidateExtension(extension, Image))
            {
                fileName = await imageService.UploadImageAsync(Image);
            }
            else
            {
                ModelState.AddModelError("AvatarFile", "We support .png, .jpg");
                return View();
            }
            DateTime time = DateTime.Now;
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            Post postDetail = new Post
            {
                Title = Title,
                Description = Description,
                UserId = user.Id,
                Created = time
            };
            await post.CreateAsync(postDetail);

            PostImage postImageDetail = new PostImage
            {
                PostId = postDetail.PostId,
                Created = time,
                ImageId = fileName
            };
            await post.CreateImageAsync(postImageDetail);
            ViewData["NavbarDetail"] = await navbarService.FindByNameAsync(User.Identity.Name);
            
            return Redirect("/");
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewData["NavbarDetail"] = await navbarService.FindByNameAsync(User.Identity.Name);
            return View();
        }
        public async Task<IActionResult> Finds()
        {
            ViewData["NavbarDetail"] = await navbarService.FindByNameAsync(User.Identity.Name);

            List<PostViewModel> postViewModels = new List<PostViewModel>();
            var posts = await post.FindAllAsync();

            foreach (var item in posts)
            {
                var image = await post.FindImageByPostIdAsync(item.PostId);
                PostViewModel postViewModel = new PostViewModel
                {
                    Title = item.Title,
                    ImageName = image.ImageId
                };
                postViewModels.Add(postViewModel);
            }

            return View(postViewModels);
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewData["NavbarDetail"] = await navbarService.FindByNameAsync(User.Identity.Name);
            
            List<PostViewModel> postViewModels = new List<PostViewModel>();
            var posts = await post.FindAllAsync();

            foreach (var item in posts)
            {
                var image = await post.FindImageByPostIdAsync(item.PostId);
                PostViewModel postViewModel = new PostViewModel
                {
                    Title = item.Title,
                    Description = item.Description,
                    ImageName = image.ImageId,
                    PostId = item.PostId
                };
                postViewModels.Add(postViewModel);
            }
            return View(postViewModels);
        }
        public async Task<IActionResult> ShowDirectPost(string postId)
        {
            PostViewModel postViewModel = null;
            ViewData["NavbarDetail"] = await navbarService.FindByNameAsync(User.Identity.Name);
            
            postViewModel = new PostViewModel
            {
                ImageName = postViewModel.ImageName,
                Title = postViewModel.Title,
                Description = postViewModel.Description,
                UserId = postViewModel.UserId,
            };
            return View(postViewModel);
        }

    }
}
