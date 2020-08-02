using System.Collections.Generic;
using System.Threading.Tasks;
using VeterinarySurgeon.Application.Specifications;

namespace VeterinarySurgeon.Application.Services
{
    public interface IEmployeeService
    {
        Task<bool> Exists(int employeeId);

        Task<EmployeeDTO> GetByIdAsync(int employeeId);

        Task<ICollection<EmployeeDTO>> ListAsyncPaged(EmployeesPaginatedWithPetsSpecification spec);

        Task<EmployeeDTO> AddPetAsync(ICollection<PetDTO> pets);

        Task<bool> Delete(int employeeId);
    }
}