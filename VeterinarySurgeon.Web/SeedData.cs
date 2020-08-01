using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using VeterinarySurgeon.Core.Entities;
using VeterinarySurgeon.Infrastructure.Data;

namespace VeterinarySurgeon.Web
{
    public static class SeedData
    {
        public static readonly Animal animal1 = new Animal("Phoenix");
        public static readonly Animal animal2 = new Animal("Owl");
        public static readonly Animal animal3 = new Animal("Hippogriff");
        public static readonly Animal animal4 = new Animal("Acromantula");
        public static readonly Animal animal5 = new Animal("Rat");
        public static readonly Animal animal6 = new Animal("Cat");

        public static readonly Animal[] animals = new Animal[] { animal1, animal2, animal3, animal4, animal5, animal6 };

        public static Employee employee1 = new Employee("Albus", "Dumbledore", true);
        public static Employee employee2 = new Employee("Harry", "Potter", true);
        public static Employee employee3 = new Employee("Rubeus", "Hagrid", true);
        public static Employee employee4 = new Employee("Ron", "Weasley", true);

        public static readonly Employee[] employees = new Employee[] { employee1, employee2, employee3, employee4};

        public static readonly FamilyMember family1 = new FamilyMember("Ginny", "Weasley", employee4);
        public static readonly FamilyMember family2 = new FamilyMember("Percy", "Weasley", employee4);
        public static readonly FamilyMember family3 = new FamilyMember("Hermione", "Granger", employee4);

        public static readonly FamilyMember[] family = new FamilyMember[] { family1, family2, family3 };

        public static readonly Pet pet1 = new Pet("Fawkes", animal1, employee1);
        public static readonly Pet pet2 = new Pet("Hedwig", animal2, employee2);
        public static readonly Pet pet3 = new Pet("Buckbeak", animal3, employee3);
        public static readonly Pet pet4 = new Pet("Pigwidgeon", animal2, employee4);
        public static readonly Pet pet5 = new Pet("Fluffy", animal2, employee3);
        public static readonly Pet pet6 = new Pet("Scabbers", animal5, employee4);
        public static readonly Pet pet7 = new Pet("Aragog", animal4, employee2);

        public static readonly Pet pet8 = new Pet("Arnold", animal2, family1);
        public static readonly Pet pet9 = new Pet("Hermes", animal2, family2);
        public static readonly Pet pet10 = new Pet("Crookshanks", animal6, family3);

        public static readonly Pet[] pets = new Pet[] { pet1, pet2, pet3, pet4, pet5, pet6, pet7, pet8, pet9, pet10 };

        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var dbContext = new AppDbContext(serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>());
            
            // Look for any TODO items.
            if (dbContext.Pets.Any())
            {
                //return;   // DB has been seeded
            }

            PopulateTestData(dbContext);
        }

        private static void PopulateTestData(AppDbContext dbContext)
        {
            // Clear previous data
            dbContext.Pets.Select(x => dbContext.Remove(x));

            dbContext.Employees.Select(x => dbContext.Remove(x));

            dbContext.FamilyMembers.Select(x => dbContext.Remove(x));

            dbContext.Animals.Select(x => dbContext.Remove(x));
            
            dbContext.SaveChanges();

            // Insert data
            dbContext.Animals.AddRange(animals);
            dbContext.Employees.AddRange(employees);
            dbContext.FamilyMembers.AddRange(family);
            dbContext.Pets.AddRange(pets);

            dbContext.SaveChanges();
        }
    }
}
