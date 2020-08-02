using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VeterinarySurgeon.Core.Entities;

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

        public int PetsCount { get; set; }

        // Mappers
        // Note: doesn't expose behavior
        public static EmployeeDTO FromEmployee(Employee item, bool includePets = true)
        {
            var result = new EmployeeDTO()
            {
                Id = item.Id,
                FamilyMembers = item.FamilyMembers == null ? new List<FamilyMemberDTO>() : FamilyMemberDTO.FromFamilyMember(item.FamilyMembers),
                IsEmployee = item.IsEmployee,
                LastName = item.LastName,
                Name = item.Name,
                PetsCount = item.PetsCount
            };

            if (includePets)
                result.Pets = item.Pets == null ? new List<PetDTO>() : PetDTO.FromPet(item.Pets);

            return result;
        }
            
    }
}