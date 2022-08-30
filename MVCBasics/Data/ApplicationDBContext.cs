using Microsoft.EntityFrameworkCore;
using MVCBasics.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace MVCBasics.Data
{
    public class ApplicationDBContext : DbContext // This is the class that manages the connection to the database
    {
        public ApplicationDBContext()
        {

        }

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }

        public DbSet<Person> People { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().HasData(new Person { Name = "Thor Odinson", Phone = "0123 456789", City = "New Asgard", ID = 1 });
            modelBuilder.Entity<Person>().HasData(new Person { Name = "Loki Odinson", Phone = "1234 567890", City = "Valhalla", ID = 2 });
            modelBuilder.Entity<Person>().HasData(new Person { Name = "Jane Foster", Phone = "2345 678901", City = "New York", ID = 3 });
            modelBuilder.Entity<Person>().HasData(new Person { Name = "Darcy Lewis", Phone = "3456 789012", City = "New York", ID = 4 });
            modelBuilder.Entity<Person>().HasData(new Person { Name = "Erik Selvig", Phone = "4567 890123", City = "Stockholm", ID = 5 });
        }
    }
}
