using System.Data;

namespace MVCBasics.Models
{
    public static class PeopleDBModel
    {

        public static List<Person> Search(List<Person> list, string keyword)
        {
            return list.FindAll(person => ContainsKeyword(person, keyword));
        }


        public static List<Person> GetPerson(List<Person> list, int id)
        {
            IEnumerable<Person> people = from person in list where person.ID == id select person;
            List<Person> match = people.ToList();
            return match;
        }


        private static bool ContainsKeyword(Person person, string keyword)
        {
            return HasName(person, keyword) || HasPhonenumber(person, keyword) || LivesInCity(person, keyword);
        }


        private static bool HasName(Person person, string name)
        {
            return person.Name.ToLower().Contains(name.ToLower());
        }


        private static bool HasPhonenumber(Person person, string phonenumber)
        {
            return person.Phone.ToLower().Contains(phonenumber.ToLower());
        }


        private static bool LivesInCity(Person person, string city)
        {
            return person.City.ToLower().Contains(city.ToLower());
        }
    }
}
