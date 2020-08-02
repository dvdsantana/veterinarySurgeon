using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
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
        public static AnimalResponse FromAnimalDTO(AnimalDTO item) =>
            new AnimalResponse()
            {
                Id = item.Id,
                Name = item.Name
            };

        public static ICollection<AnimalResponse> FromAnimalDTO(ICollection<AnimalDTO> items) =>
            items.Select(x => FromAnimalDTO(x)).ToList();

        public static AnimalDTO FromAnimalDTO(AnimalResponse item) => 
            new AnimalDTO()
            {
                Id = item.Id,
                Name = item.Name
            };
    }
}