using Microsoft.EntityFrameworkCore;
using MVCBasics.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;
using System.Xml.Linq;

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

        public DbSet<Person> People => Set<Person>();

        public DbSet<City> Cities => Set<City>();

        public DbSet<Country> Countries => Set<Country>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Countries
            modelBuilder.Entity<Country>().HasData(new Country { ID = 1, Name = "Norway"});
            modelBuilder.Entity<Country>().HasData(new Country { ID = 2, Name = "USA" });
            modelBuilder.Entity<Country>().HasData(new Country { ID = 3, Name = "Sweden" });

            //Cities
            modelBuilder.Entity<City>().HasData(new { ID = 1, Name = "New Asgard", CountryID = 1});
            modelBuilder.Entity<City>().HasData(new { ID = 2, Name = "Jotunheim", CountryID = 1 });

            modelBuilder.Entity<City>().HasData(new { ID = 3, Name = "New York", CountryID = 2 });
            modelBuilder.Entity<City>().HasData(new { ID = 4, Name = "Westview", CountryID = 2 });

            modelBuilder.Entity<City>().HasData(new { ID = 5, Name = "Göteborg", CountryID = 3 });
            modelBuilder.Entity<City>().HasData(new { ID = 6, Name = "Alingsås", CountryID = 3 });

            //People
            modelBuilder.Entity<Person>().HasData(new { ID = 1, Name = "Thor Odinson", Phone = "0123 456789", CityID = 1 });
            modelBuilder.Entity<Person>().HasData(new { ID = 2, Name = "Valkyrie", Phone = "0123 456789", CityID = 1 });
            modelBuilder.Entity<Person>().HasData(new { ID = 3, Name = "Sif", Phone = "7777 777777", CityID = 1 });

            modelBuilder.Entity<Person>().HasData(new { ID = 4, Name = "Loki Odinson", Phone = "1234 567890", CityID = 2 });
            modelBuilder.Entity<Person>().HasData(new { ID = 5, Name = "Sylvie Laufeysdottir", Phone = "0000 000000", CityID = 2 });

            modelBuilder.Entity<Person>().HasData(new { ID = 6, Name = "Jane Foster", Phone = "2345 678901", CityID = 3 });
            modelBuilder.Entity<Person>().HasData(new { ID = 7, Name = "Tony Stark", Phone = "9999 999999", CityID = 3 });
            modelBuilder.Entity<Person>().HasData(new { ID = 8, Name = "Nick Fury", Phone = "8888 888888", CityID = 3 });
            modelBuilder.Entity<Person>().HasData(new { ID = 9, Name = "Natasha Romanoff", Phone = "8888 888888", CityID = 3 });

            modelBuilder.Entity<Person>().HasData(new { ID = 10, Name = "Darcy Lewis", Phone = "3456 789012", CityID = 4 });
            modelBuilder.Entity<Person>().HasData(new { ID = 11, Name = "Wanda Maximoff", Phone = "5555 555555", CityID = 4 });
            modelBuilder.Entity<Person>().HasData(new { ID = 12, Name = "Vision", Phone = "5555 555555", CityID = 4 });

            modelBuilder.Entity<Person>().HasData(new { ID = 13, Name = "Erik Selvig", Phone = "4567 890123", CityID = 5 });
            modelBuilder.Entity<Person>().HasData(new { ID = 14, Name = "Jenny Rigsjö", Phone = "0763 446373", CityID = 6 });
        }
    }
}
