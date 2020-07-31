using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using VeterinarySurgeon.Web.Endpoints.Pet;

namespace VeterinarySurgeon.Web.Endpoints.Employee
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

        public EmployeeResponse Employee { get; set; }

        public ICollection<PetResponse> Pets { get; set; }


        // Mappers from entity to Responses
        // Note: doesn't expose behavior
        public static FamilyMemberResponse FromFamilyMember(Core.Entities.FamilyMember item) =>
            new FamilyMemberResponse()
            {
                Id = item.Id,
                Employee = EmployeeResponse.FromEmployee(item.Employee),
                LastName = item.LastName,
                Name = item.Name,
                Pets = PetResponse.FromPet(item.Pets)
            };

        public static ICollection<FamilyMemberResponse> FromFamilyMember(ICollection<Core.Entities.FamilyMember> items) =>
            items.Select(x => FromFamilyMember(x)).ToList();
    }
}
