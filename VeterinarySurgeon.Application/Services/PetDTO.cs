using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using VeterinarySurgeon.Core.Entities;

namespace VeterinarySurgeon.Application.Services
{
    public class PetDTO
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public AnimalDTO Animal { get; set; }

        // Mappers from entity to Responses
        // Note: doesn't expose behavior
        public static PetDTO FromPet(Pet item) =>
            new PetDTO()
            {
                Id = item.Id,
                Animal = AnimalDTO.FromAnimal(item.Animal),
                Name = item.Name
            };

        public static ICollection<PetDTO> FromPet(ICollection<Pet> items) =>
            items.Select(x => FromPet(x)).ToList();
    }
}
