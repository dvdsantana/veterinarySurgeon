using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using VeterinarySurgeon.Application.Services;

namespace VeterinarySurgeon.Web.Endpoints.Pet
{
    public class CreatePetRequest
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public int AnimalId { get; set; }

        [Required]
        public int EmployeeId { get; set; }

        public static PetDTO FromPetRequest(CreatePetRequest item) =>
            new PetDTO()
            {
                AnimalId = item.AnimalId,
                EmployeeId = item.EmployeeId,
                Name = item.Name
            };

        public static ICollection<PetDTO> FromPetRequest(ICollection<CreatePetRequest> items) =>
            items.Select(x => CreatePetRequest.FromPetRequest(x)).ToList();
    }
}