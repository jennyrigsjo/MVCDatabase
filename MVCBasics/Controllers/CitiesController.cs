using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVCBasics.Data;
using MVCBasics.Models;
using MVCBasics.ViewModels;

namespace MVCBasics.Controllers
{
    public class CitiesController : Controller
    {
        public CitiesController(ApplicationDBContext database)
        {
            Database = database;
        }


        private readonly ApplicationDBContext Database;

        public IActionResult Index()
        {
            CitiesViewModel cities = new()
            {
                List = Database.Cities.Include(p => p.Country).ToList()
            };

            return View(cities);
        }
    }
}
