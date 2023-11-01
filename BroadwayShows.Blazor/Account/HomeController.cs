using Microsoft.AspNetCore.Mvc;

namespace BroadwayShows.Blazor.Account
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
