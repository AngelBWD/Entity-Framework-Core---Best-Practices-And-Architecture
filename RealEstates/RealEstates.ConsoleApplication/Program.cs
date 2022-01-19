using Microsoft.EntityFrameworkCore;
using RealEstates.Data;
using RealEstates.Models;
using RealEstates.Services;

namespace RealEstates.ConsoleApplication
{
    class Program
    {
        static void Main (string[] args)
        {
            var db = new ApplicationDbContext();
            db.Database.Migrate();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Choose an option");
                Console.WriteLine("1. Property search");
                Console.WriteLine("2. Most expensive districts");
                Console.WriteLine("0. EXIT");
                bool parsed = int.TryParse(Console.ReadLine(), out int option);
                if (parsed && option == 0)
                {
                    break;
                }

                if (parsed && option >= 1 && option <= 2)
                {
                    switch (option)
                    {
                        case 1:
                            PropertySearch(db);
                            break;
                        case 2:
                            MostExpensiveDistricts(db);
                            break;
                    }

                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
            }
        }

        private static void MostExpensiveDistricts(ApplicationDbContext db)
        {
            
        }
        private static void PropertySearch(ApplicationDbContext db)
        {
            Console.WriteLine("Min price:");
            int minPrice = int.Parse(Console.ReadLine());
            Console.WriteLine("Max price:");
            int maxPrice = int.Parse(Console.ReadLine());
            Console.WriteLine("Min size:");
            int minSize = int.Parse(Console.ReadLine());
            Console.WriteLine("Max size:");
            int maxSize = int.Parse(Console.ReadLine());

            IPropertiesService servise = new PropertiesService(db);
            var properties = servise.Search(minPrice, maxPrice, minSize, maxSize);
            foreach (var property in properties)
            {
                Console.WriteLine($"{property.DistrictName}; {property.BuildingType}; {property.PropertyType} => {property.Price}$ => {property.Size}");
            }
        }

    }
}