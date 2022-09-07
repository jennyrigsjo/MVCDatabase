using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using MVCBasics.Data;
using MVCBasics.Models;
using MVCBasics.ViewModels;

namespace MVCBasics.Controllers
{
    public class AjaxController : Controller
    {
        public AjaxController(ApplicationDBContext database)
        {
            Database = database;
        }


        private readonly ApplicationDBContext Database;


        public IActionResult Index()
        {
            return View();
        }


        public IActionResult PeopleList()
        {
            PeopleViewModel viewModel = new()
            {
                List = Database.People.ToList()
            };

            return View("_PeopleList", viewModel);
        }


        [HttpPost]
        public IActionResult GetPerson(int id = 0)
        {
            List<Person> list = new();
            var person = Database.People
                .Include(p => p.City)
                .Include(p => p.Languages)
                .Where(p => p.ID == id)
                .ToList()
                .FirstOrDefault();

            if (person != null)
            {
                list.Add(person);
            }

            PeopleViewModel viewModel = new()
            {
                List = list
            };

            return View("_PersonDetails", viewModel);
        }


        [HttpPost]
        public IActionResult DeletePerson(int id = 0)
        {
            if (id == 0)
            {
                return BadRequest(); // Setting status code to anything other than 2** will trigger the 'error' part of the javascript/ajax call.
            }
            
            List<Person> match = (from p in Database.People where p.ID == id select p).ToList();

            if (match.Any() == false)
            {
                return NotFound();
            }

            else
            {
                var person = match.First();
                Database.People.Remove(person);
                Database.SaveChanges();
                return Ok();
            }
        }
    }
}
