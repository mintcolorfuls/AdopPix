using AdopPix.Models;
using AdopPix.Procedure;
using AdopPix.Procedure.IProcedure;
using AdopPix.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AdopPix.Controllers
{
    [Authorize]
    public class PostController : Controller
    {
        private readonly INavbarService navbarService;
        private readonly IPostProcedure post;
        private readonly UserManager<User> userManager;
        public PostController(IPostProcedure post,INavbarService navbarService,UserManager<User> userManager)
        {
            this.post = post;
            this.navbarService = navbarService;
            this.userManager = userManager;
        }
        DateTime time = DateTime.Now;
        [HttpPost]
        public async Task<IActionResult> Create(string Title, string Description,string ImageId)
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            Post postDetail = new Post
            {
                Title = Title,
                Description = Description,
                UserId = user.Id,
                Created = time
            };
            PostImage postImageDetail = new PostImage
            {
                PostId = postDetail.PostId,
                Created = time,
                ImageId = ImageId
            };
            ViewData["NavbarDetail"] = await navbarService.FindByNameAsync(User.Identity.Name);
            await post.CreateAsync(postDetail);
            await post.CreateImageAsync(postImageDetail);
            return Redirect("/");
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewData["NavbarDetail"] = await navbarService.FindByNameAsync(User.Identity.Name);
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Show()
        {
            ViewData["NavbarDetail"] = await navbarService.FindByNameAsync(User.Identity.Name);
            await post.FindByPostIdAsync();
            return View();
        }
    }
}
