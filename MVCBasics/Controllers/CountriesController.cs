using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVCBasics.Data;
using MVCBasics.Models;
using MVCBasics.ViewModels;

namespace MVCBasics.Controllers
{
    public class CountriesController : Controller
    {
        public CountriesController(ApplicationDBContext database)
        {
            Database = database;
        }


        private readonly ApplicationDBContext Database;

        public IActionResult Index()
        {
            CountriesViewModel countries = new()
            {
                List = Database.Countries.ToList()
            };

            return View(countries);
        }
    }
}
