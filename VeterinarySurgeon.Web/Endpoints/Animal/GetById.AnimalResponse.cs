using System.ComponentModel.DataAnnotations;
using VeterinarySurgeon.Application.Services;

namespace VeterinarySurgeon.Web.Endpoints.Animal
{
    public class AnimalResponse
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        // Mappers
        // Note: doesn't expose behavior
        public static AnimalResponse FromAnimal(AnimalDTO item) =>
            new AnimalResponse()
            {
                Id = item.Id,
                Name = item.Name
            };

        public static AnimalDTO FromAnimalDTO(AnimalResponse item) => new AnimalDTO()
        {
            Id = item.Id,
            Name = item.Name
        };
    }
}
