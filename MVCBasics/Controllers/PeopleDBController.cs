using Microsoft.AspNetCore.Mvc;
using MVCBasics.Data;
using MVCBasics.Models;
using MVCBasics.ViewModels;

namespace MVCBasics.Controllers
{
    public class PeopleDBController : Controller
    {

        public PeopleDBController(ApplicationDBContext database)
        {
            Database = database;
        }


        private readonly ApplicationDBContext Database;


        [HttpGet]
        public IActionResult Index()
        {
            ViewModelsContainer viewModels = new()
            {
                People = new PeopleViewModel()
                {
                    List = Database.People.ToList()
                }
            };

            return View(viewModels);
        }


        [HttpPost]
        public IActionResult Search(string search)
        {
            ViewModelsContainer viewModels = new()
            {
                People = new PeopleViewModel()
                {
                    Search = search,
                    List = PeopleDBModel.Search(Database.People.ToList(), search)
                }
            };

            return View("Index", viewModels);
        }


        [HttpPost]
        public IActionResult CreatePerson(CreatePersonViewModel person)
        {
            ViewModelsContainer viewModels = new()
            {
                People = new PeopleViewModel(),
                CreatePerson = new CreatePersonViewModel()
            };

            if (ModelState.IsValid)
            {
                Person newPerson = new (person.Name, person.Phone, person.City);
                Database.People.Add(newPerson);
                Database.SaveChanges();
            }
            else
            {
                // return supplied info to view to keep form fields filled in
                viewModels.CreatePerson.Name = person.Name;
                viewModels.CreatePerson.Phone = person.Phone;
                viewModels.CreatePerson.City = person.City;
            }

            viewModels.People.List = Database.People.ToList();
            return View("Index", viewModels);
        }


        [HttpGet]
        public IActionResult DeletePerson(int id = 0)
        {

            List<Person> match = PeopleDBModel.GetPerson(Database.People.ToList(), id);

            if (match.Any())
            {
                var person = match.First();
                Database.People.Remove(person);
                Database.SaveChanges();
            }

            ViewModelsContainer viewModels = new()
            {
                People = new PeopleViewModel()
                {
                    List = Database.People.ToList(),
                }
            };

            return View("Index", viewModels);
        }
    }
}
