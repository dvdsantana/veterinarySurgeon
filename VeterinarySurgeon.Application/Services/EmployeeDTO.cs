using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VeterinarySurgeon.Application.Services
{
    public class EmployeeDTO
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string LastName { get; set; }

        public string FullName => $"{Name} {LastName}";

        public bool IsEmployee { get; set; } = true;

        public ICollection<FamilyMemberDTO> FamilyMembers { get; set; }

        public ICollection<PetDTO> Pets { get; set; }

        // Mappers from entity to DTOs
        // Note: doesn't expose behavior
        public static EmployeeDTO FromEmployee(Core.Entities.Employee item) =>
            new EmployeeDTO()
            {
                Id = item.Id,
                FamilyMembers = item.FamilyMembers == null ? new List<FamilyMemberDTO>() : FamilyMemberDTO.FromFamilyMember(item.FamilyMembers),
                IsEmployee = item.IsEmployee,
                LastName = item.LastName,
                Name = item.Name,
                Pets = item.Pets == null ? new List<PetDTO>() : PetDTO.FromPet(item.Pets)
            };
    }
}
