using System.ComponentModel.DataAnnotations;

namespace VeterinarySurgeon.Web.Endpoints.Employee
{
    public class CreateEmployeeRequest
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string LastName { get; set; }
    }
}
