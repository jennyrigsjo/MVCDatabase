using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVCBasics.Data;
using MVCBasics.Models;
using MVCBasics.ViewModels;

namespace MVCBasics.Controllers
{
    public class PeopleController : Controller
    {

        public PeopleController(ApplicationDBContext database)
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
                    List = Database.People.Include(p => p.City).ToList(),
                },
                CreatePerson = new CreatePersonViewModel()
                {
                    SelectCity = new SelectList(Database.Cities, "ID", "Name")
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
                    List = Database.People
                    .Include(p => p.City)
                    .Where(p => p.Name.Contains(search) || p.Phone.Contains(search) || p.City.Name.Contains(search)).ToList(),
                },
                CreatePerson = new CreatePersonViewModel()
                {
                    SelectCity = new SelectList(Database.Cities, "ID", "Name")
                }
            };

            return View("Index", viewModels);
        }


        /*
         * TODO: present selectable city options based on user's choice of country (requires ajax?)
         * TODO: return custom message if selected city option/id is invalid
         * TODO: find more 'framework native' way to verify selected city exists
         */
        [HttpPost]
        public IActionResult CreatePerson(CreatePersonViewModel person)
        {
            int cityID = int.Parse(person.City);
            bool cityExists = Database.Cities.ToList().Exists(c => c.ID == cityID);

            CreatePersonViewModel createPerson = new()
            {
                SelectCity = new SelectList(Database.Cities, "ID", "Name")
            };

            if (ModelState.IsValid && cityExists)
            {
                City city = Database.Cities.Where(c => c.ID == cityID).ToList().First();
                Person newPerson = new (person.Name, person.Phone, city);
                Database.People.Add(newPerson);
                Database.SaveChanges();
            }
            else
            {
                createPerson.Name = person.Name;
                createPerson.Phone = person.Phone;
                createPerson.City = person.City;
            }

            ViewModelsContainer viewModels = new()
            {
                People = new PeopleViewModel()
                {
                    List = Database.People.Include(p => p.City).ToList(),
                },
                CreatePerson = createPerson
            };

            return View("Index", viewModels);
        }


        [HttpGet]
        public IActionResult DeletePerson(int id = 0)
        {
            List<Person> match = (from p in Database.People where p.ID == id select p).ToList();

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
                    List = Database.People.Include(p => p.City).ToList(),
                },
                CreatePerson = new CreatePersonViewModel()
                {
                    SelectCity = new SelectList(Database.Cities, "ID", "Name")
                }
            };

            return View("Index", viewModels);
        }
    }
}
