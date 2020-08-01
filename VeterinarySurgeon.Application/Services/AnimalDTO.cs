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

        // Mappers from entity to DTOs
        // Note: doesn't expose behavior
        public static AnimalDTO FromAnimal(Animal item) =>
            new AnimalDTO()
            {
                Id = item.Id,
                Name = item.Name
            };
    }
}
