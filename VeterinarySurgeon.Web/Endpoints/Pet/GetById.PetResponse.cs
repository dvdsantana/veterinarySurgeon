using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using VeterinarySurgeon.Web.Endpoints.Animal;
using VeterinarySurgeon.Web.Endpoints.Employee;

namespace VeterinarySurgeon.Web.Endpoints.Pet
{
    public class PetResponse
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public EmployeeResponse Owner { get; set; }

        [Required]
        public AnimalResponse Animal { get; set; }


        // Mappers from entity to Responses
        // Note: doesn't expose behavior
        public static PetResponse FromPet(Core.Entities.Pet item) =>
            new PetResponse()
            {
                Id = item.Id,
                Animal = AnimalResponse.FromAnimal(item.Animal),
                Name = item.Name,
                Owner = EmployeeResponse.FromEmployee(item.Owner)
            };

        public static ICollection<PetResponse> FromPet(ICollection<Core.Entities.Pet> items) =>
            items.Select(x => FromPet(x)).ToList();
    }
}
