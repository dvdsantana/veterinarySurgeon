using System.ComponentModel.DataAnnotations;

namespace VeterinarySurgeon.Web.Endpoints.Employee
{
    public class AddPetRequest
    {
        [Required]
        public int EmployeeId { get; set; }

        [Required]
        public string PetName { get; set; }

        [Required]
        public int AnimalId { get; set; }
    }
}
