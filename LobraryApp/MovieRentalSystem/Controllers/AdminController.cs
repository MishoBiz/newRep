using Microsoft.AspNetCore.Mvc;

namespace MovieRentalSystem.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
