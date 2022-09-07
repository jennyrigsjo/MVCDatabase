using Microsoft.AspNetCore.Mvc;
using MVCBasics.Data;
using MVCBasics.ViewModels;

namespace MVCBasics.Controllers
{
    public class LanguagesController : Controller
    {

        public LanguagesController(ApplicationDBContext database)
        {
            Database = database;
        }


        private readonly ApplicationDBContext Database;

        public IActionResult Index()
        {
            LanguagesViewModel languages = new()
            {
                List = Database.Languages.ToList(),
            };
            return View(languages);
        }
    }
}
