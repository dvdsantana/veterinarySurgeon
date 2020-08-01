using System.Collections.Generic;
using System.Threading.Tasks;
using VeterinarySurgeon.Application.Specifications;

namespace VeterinarySurgeon.Application.Services
{
    public interface IEmployeeService
    {
        Task<EmployeeDTO> GetById(int employeeId);
        Task<ICollection<EmployeeDTO>> ListAsyncPaged(EmployeesPaginatedWithPetsSpecification spec);
    }
}