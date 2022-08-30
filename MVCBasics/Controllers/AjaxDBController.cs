using Microsoft.AspNetCore.Mvc;
using MVCBasics.Data;
using MVCBasics.Models;
using MVCBasics.ViewModels;

namespace MVCBasics.Controllers
{
    public class AjaxDBController : Controller
    {
        public AjaxDBController(ApplicationDBContext database)
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
            PeopleViewModel viewModel = new()
            {
                List = PeopleDBModel.GetPerson(Database.People.ToList(), id)
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

            List<Person> match = PeopleDBModel.GetPerson(Database.People.ToList(), id);

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
