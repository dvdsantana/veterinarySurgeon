using System.ComponentModel.DataAnnotations;

namespace VeterinarySurgeon.Web.Endpoints.Animal
{
    public class AnimalResponse
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        // Mappers from entity to DTOs
        // Note: doesn't expose behavior
        public static AnimalResponse FromAnimal(Core.Entities.Animal item) =>
            new AnimalResponse()
            {
                Id = item.Id,
                Name = item.Name
            };
    }
}
