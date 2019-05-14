using AlfavoxPoC.Core.Domain;
using AlfavoxPoC.Core.Enums;
using System.Linq;

namespace AlfavoxPoC.Persistence
{
    public class DbInitializer
    {
        public static void Initialize(AlfavoxDbContext context)
        {
            // EnsureCreated will cause the database to be created
            // whenever it's needed to be. If it's already there
            // it won't do anything
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            // Check if specified table has any data in it
            // if not, then create some dummy data 
            if (context.Compenies.Any() && context.Employees.Any())
            {
                return;
            }

            // Create loads of Dummy Data
            var products = new Product[]
            {
                new Product() { Title = "Video Chat", BriefContent = "najlepszy sposób na wzrost konwersji w..", Type = ProductType.Customer },
                new Product() { Title = "Omnichannel Desktop", BriefContent = "zwiększ zysk swojej firmy", Type = ProductType.Employee }
            };

            foreach (var product in products)
            {
                context.Products.Add(product);
            }
            context.SaveChanges();

            var locations = new Location[]
            {
                new Location() { Country = "Poland", City = "Bielsko-Biała", PostCode = "7777" },
                new Location() { Country = "Poland", City = "Warszawa", PostCode = "8888" },
            };

            foreach (var location in locations)
            {
                context.Locations.Add(location);
            }
            context.SaveChanges();

            var employees = new Employee[]
            {
                new Employee() { FirstName = "Paweł", LastName = "Rudnicki", Position = "Software Engineer" },
                new Employee() { FirstName = "Jan", LastName = "Kowalski", Position = "Quality Assurance" }
            };

            foreach (var employee in employees)
            {
                context.Employees.Add(employee);
            }
            context.SaveChanges();

            var company = new Company()
            {
                Name = "Alfavox"
            };

            context.Compenies.Add(company);
            context.SaveChanges();
        }
    }
}
