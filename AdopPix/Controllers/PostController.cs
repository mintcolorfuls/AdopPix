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
        private readonly IPostProcedure postProcedure;
        private readonly UserManager<User> userManager;
        private readonly IImageService imageService;

        public PostController(IPostProcedure post,
                              INavbarService navbarService,
                              UserManager<User> userManager,
                              IImageService imageService)
        {
            this.postProcedure = post;
            this.navbarService = navbarService;
            this.userManager = userManager;
            this.imageService = imageService;
        }

        [HttpGet("Post/Create")]
        public async Task<IActionResult> Create()
        {
            ViewData["NavbarDetail"] = await navbarService.FindByNameAsync(User.Identity.Name);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(string Title, string Description, IFormFile Image)
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
            await postProcedure.CreateAsync(postDetail);

            PostImage postImageDetail = new PostImage
            {
                PostId = postDetail.PostId,
                Created = time,
                ImageId = fileName
            };
            await postProcedure.CreateImageAsync(postImageDetail);
            ViewData["NavbarDetail"] = await navbarService.FindByNameAsync(User.Identity.Name);

            return Redirect("/");
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewData["NavbarDetail"] = await navbarService.FindByNameAsync(User.Identity.Name);

            List<PostViewModel> postViewModels = new List<PostViewModel>();
            var posts = await postProcedure.FindAllAsync();

            foreach (var item in posts)
            {
                var image = await postProcedure.FindImageByPostIdAsync(item.PostId);
                PostViewModel postViewModel = new PostViewModel
                {
                    Title = item.Title,
                    ImageName = image.ImageId,
                    PostId = item.PostId
                };
                postViewModels.Add(postViewModel);
            }

            return View(postViewModels);
        }

        [HttpGet("Post/{id}")]
        public async Task<IActionResult> FindById(string id = "")
        {
            ViewData["NavbarDetail"] = await navbarService.FindByNameAsync(User.Identity.Name);

            var post = await postProcedure.FindByPostId(id);
            if (post == null)
            {
                return null;
            }

            var user = await userManager.FindByIdAsync(post.UserId);
            var image = await postProcedure.FindImageByPostIdAsync(id);

            ShowDirectPostViewModel showDirectPostViewModel = new ShowDirectPostViewModel
            {
                PostId = post.PostId,
                Title = post.Title,
                Description = post.Description,
                UserName = user.UserName,
                ImageName = image.ImageId
            };

            ViewData["Post"] = showDirectPostViewModel;

            return View();
        }
        [HttpGet("/post/remove/{id}")]
        public async Task<IActionResult> DeleteById(string id)
        {
            // หาว่าต้องลบโพสไหน
            var post = await postProcedure.FindByPostId(id);
            // หาว่าต้องลบภาพจากโพสไหน
            var postImage = await postProcedure.FindImageByPostIdAsync(id);
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
            await postProcedure.DeleteImageAsync(postImage);
            // ลบโพสตามที่ตรวจเจอ
            await postProcedure.DeletePostAsync(post);
            

            return Redirect("/Post");
        }


    }
}
