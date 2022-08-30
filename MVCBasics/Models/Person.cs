using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCBasics.Models
{
    public class Person
    {
        public Person() //Empty constructor needed to avoid 'missing argument' error when adding seed data in ApplicationDBContext
        {

        }

        public Person(string name, string phone, string city)
        {
            Name = name;
            Phone = phone;
            City = city;
        }

        public string Name { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;

        public string City { get; set; } = string.Empty;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
    }
}
