using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using VeterinarySurgeon.Application.Services;
using VeterinarySurgeon.Web.Endpoints.FamilyMember;
using VeterinarySurgeon.Web.Endpoints.Pet;

namespace VeterinarySurgeon.Web.Endpoints.Employee
{
    public class EmployeeResponse
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string LastName { get; set; }

        public string FullName => $"{Name} {LastName}";

        public bool IsEmployee { get; set; } = true;

        public ICollection<FamilyMemberResponse> FamilyMembers { get; set; }

        public ICollection<PetResponse> Pets { get; set; }

        // Mappers
        // Note: doesn't expose behavior
        public static EmployeeResponse FromEmployeeDTO(EmployeeDTO item) =>
            new EmployeeResponse()
            {
                Id = item.Id,
                FamilyMembers = item.FamilyMembers == null ? new List<FamilyMemberResponse>() : FamilyMemberResponse.FromFamilyMember(item.FamilyMembers),
                IsEmployee = item.IsEmployee,
                LastName = item.LastName,
                Name = item.Name,
                Pets = item.Pets == null ? new List<PetResponse>() : PetResponse.FromPet(item.Pets)
            };

        public static ICollection<EmployeeResponse> FromEmployeeDTO(ICollection<EmployeeDTO> items) =>
            items.Select(x => EmployeeResponse.FromEmployeeDTO(x)).ToList();
    }
}
