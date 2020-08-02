using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using VeterinarySurgeon.Core.Entities;

namespace VeterinarySurgeon.Application.Services
{
    public class FamilyMemberDTO
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string LastName { get; set; }

        public string FullName => $"{Name} {LastName}";

        public ICollection<PetDTO> Pets { get; set; }

        // Mappers
        // Note: doesn't expose behavior
        public static FamilyMemberDTO FromFamilyMember(FamilyMember item) =>
            new FamilyMemberDTO()
            {
                Id = item.Id,
                LastName = item.LastName,
                Name = item.Name,
                Pets = item.Pets == null ? new List<PetDTO>() : PetDTO.FromPet(item.Pets)
            };

        public static ICollection<FamilyMemberDTO> FromFamilyMember(ICollection<FamilyMember> items) =>
            items.Select(x => FromFamilyMember(x)).ToList();
    }
}