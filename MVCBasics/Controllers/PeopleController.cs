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
                    List = Database.People.Include(p => p.City).Include(p => p.Languages).ToList(),
                },
                CreatePerson = new CreatePersonViewModel()
                {
                    SelectCity = new SelectList(Database.Cities, "ID", "Name"),
                    SelectLanguages = new MultiSelectList(Database.Languages, "ID", "Name")
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
                    .Include(p => p.Languages)
                    .Where(p => p.Name.Contains(search) || p.Phone.Contains(search) || p.City.Name.Contains(search)).ToList(),
                },
                CreatePerson = new CreatePersonViewModel()
                {
                    SelectCity = new SelectList(Database.Cities, "ID", "Name"),
                    SelectLanguages = new MultiSelectList(Database.Languages, "ID", "Name")
                }
            };

            return View("Index", viewModels);
        }


        /*
         * TODO: present selectable city options based on user's choice of country (requires ajax?)
         */
        [HttpPost]
        public IActionResult CreatePerson(CreatePersonViewModel model)
        {
            if (ModelState.IsValid)
            {
                City city = Database.Cities.Where(c => c.ID == model.City).ToList().First();
                List<Language> languages = (model.Languages == null) ? new List<Language>() : Database.Languages.Where(l => model.Languages.Contains(l.ID)).ToList();
                
                Person person = new (model.Name, model.Phone, city, languages);

                Database.People.Add(person);
                Database.SaveChanges();
            }

            ViewModelsContainer viewModels = new()
            {
                People = new PeopleViewModel()
                {
                    List = Database.People.Include(p => p.City).Include(p => p.Languages).ToList(),
                },
                CreatePerson = model
            };

            viewModels.CreatePerson.SelectCity = new SelectList(Database.Cities, "ID", "Name");
            viewModels.CreatePerson.SelectLanguages = new MultiSelectList(Database.Languages, "ID", "Name");

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
                    List = Database.People.Include(p => p.City).Include(p => p.Languages).ToList(),
                },
                CreatePerson = new CreatePersonViewModel()
                {
                    SelectCity = new SelectList(Database.Cities, "ID", "Name"),
                    SelectLanguages = new MultiSelectList(Database.Languages, "ID", "Name")
                }
            };

            return View("Index", viewModels);
        }
    }
}
