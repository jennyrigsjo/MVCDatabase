using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCBasics.Models
{
    public class City
    {
        public City()
        {

        }

        public City(string name)
        {
            Name = name;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public string Name { get; set; } = string.Empty;

        public List<Person> People { get; set; } = new List<Person>();

        public Country Country { get; set; } = new Country();

    }
}
