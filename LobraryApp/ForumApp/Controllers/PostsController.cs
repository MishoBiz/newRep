using ForumApp.Data;
using ForumApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace ForumApp.Controllers
{
    public class PostsController : Controller
    {
        private readonly ApplicationDbContext data;

        public PostsController(ApplicationDbContext _data)
        {
            data = _data;
        }
        public IActionResult All()
        {
            var posts = this.data
                .Posts
                .Select(p => new PostViewModel()
                {
                    Id = p.Id,
                    Title = p.Title,
                    Content = p.Content
                })
                .ToList();

            return View(posts);
        }
    }
}
