using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using VeterinarySurgeon.Application.Services;
using VeterinarySurgeon.Web.Endpoints.Pet;

namespace VeterinarySurgeon.Web.Endpoints.FamilyMember
{
    public class FamilyMemberResponse
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string LastName { get; set; }

        public string FullName => $"{Name} {LastName}";

        public ICollection<PetResponse> Pets { get; set; }


        // Mappers
        // Note: doesn't expose behavior
        public static FamilyMemberResponse FromFamilyMember(FamilyMemberDTO item) =>
            new FamilyMemberResponse()
            {
                Id = item.Id,
                LastName = item.LastName,
                Name = item.Name,
                Pets = item.Pets == null ? new List<PetResponse>() : PetResponse.FromPet(item.Pets)
            };

        public static ICollection<FamilyMemberResponse> FromFamilyMember(ICollection<FamilyMemberDTO> items) =>
            items.Select(x => FromFamilyMember(x)).ToList();
    }
}
