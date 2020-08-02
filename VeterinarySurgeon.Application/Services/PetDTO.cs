using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using VeterinarySurgeon.Core.Entities;

namespace VeterinarySurgeon.Application.Services
{
    public class PetDTO
    {
        public int Id { get; set; }

        public int EmployeeId { get; set; }

        [Required]
        public EmployeeDTO Employee { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public AnimalDTO Animal { get; set; }

        public int AnimalId { get; set; }

        // Mappers
        // Note: doesn't expose behavior
        public static PetDTO FromPet(Pet item) =>
            new PetDTO()
            {
                Id = item.Id,
                AnimalId = item.AnimalId,
                Animal = AnimalDTO.FromAnimal(item.Animal),
                Name = item.Name,
                Employee = EmployeeDTO.FromEmployee(item.Owner, false)
            };

        public static Pet FromPetDTO(PetDTO item) =>
            new Pet(item.Name, item.AnimalId, item.EmployeeId);

        public static ICollection<PetDTO> FromPet(ICollection<Pet> items) =>
            items.Select(x => FromPet(x)).ToList();

        public static ICollection<Pet> FromPetDTO(ICollection<PetDTO> items) =>
            items.Select(x => FromPetDTO(x)).ToList();
    }
}