using Microsoft.AspNetCore.Mvc;
using MVCBasics.Models;

namespace MVCBasics.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public async Task<IActionResult> Projects()
        {
            ViewBag.Repos = await GitHubModel.GetLatestUserRepos("https://api.github.com/users/jennyrigsjo/repos");
            return View();
        }
    }
}
