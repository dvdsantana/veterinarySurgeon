using System.ComponentModel.DataAnnotations;
using VeterinarySurgeon.Core.Entities;

namespace VeterinarySurgeon.Application.Services
{
    public class AnimalDTO
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        // Mappers
        // Note: doesn't expose behavior
        public static AnimalDTO FromAnimal(Animal item) =>
            new AnimalDTO()
            {
                Id = item.Id,
                Name = item.Name
            };

        public static Animal FromAnimalDTO(AnimalDTO item) => new Animal(item.Name);
    }
}