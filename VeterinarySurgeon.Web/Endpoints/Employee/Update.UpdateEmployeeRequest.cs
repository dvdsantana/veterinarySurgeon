using System.Collections.Generic;
using VeterinarySurgeon.Web.Endpoints.Pet;

namespace VeterinarySurgeon.Web.Endpoints.Employee
{
    public class UpdateEmployeeRequest
    {
        public ICollection<CreatePetRequest> Pets { get; set; }
    }
}
