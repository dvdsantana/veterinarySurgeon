using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using VeterinarySurgeon.Core.Entities;
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

        // Mappers from entity to DTOs
        // Note: doesn't expose behavior
        public static EmployeeResponse FromEmployee(Core.Entities.Employee item) =>
            new EmployeeResponse()
            {
                Id = item.Id,
                FamilyMembers = FamilyMemberResponse.FromFamilyMember(item.FamilyMembers),
                IsEmployee = item.IsEmployee,
                LastName = item.LastName,
                Name = item.Name,
                Pets = PetResponse.FromPet(item.Pets)
            };
    }
}
