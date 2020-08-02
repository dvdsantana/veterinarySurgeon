using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using VeterinarySurgeon.Application.Services;
using VeterinarySurgeon.Web.Endpoints.Animal;
using VeterinarySurgeon.Web.Endpoints.Employee;

namespace VeterinarySurgeon.Web.Endpoints.Pet
{
    public class PetResponse
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public AnimalResponse Animal { get; set; }

        [Required]
        public EmployeeResponse Owner { get; set; }

        // Mappers
        // Note: doesn't expose behavior
        public static PetResponse FromPetDTO(PetDTO item) =>
            new PetResponse()
            {
                Id = item.Id,
                Animal = AnimalResponse.FromAnimal(item.Animal),
                Name = item.Name,
                Owner = EmployeeResponse.FromEmployeeDTO(item.Employee)
            };

        public static ICollection<PetResponse> FromPetDTO(ICollection<PetDTO> items) =>
            items.Select(x => FromPetDTO(x)).ToList();

        //public static PetDTO FromPetResponse(PetResponse item) =>
        //    new PetDTO()
        //    {
        //        Animal = AnimalResponse.FromAnimalDTO(item.Animal),
        //        Employee = EmployeeResponse.FromEmployeeDTO(item.Employee),
        //        Id = item.Id,
        //        Name = item.Name
        //    };

        //public static ICollection<PetDTO> FromPetResponse(ICollection<PetResponse> items) =>
        //    items.Select(x => FromPetResponse(x)).ToList();
    }
}