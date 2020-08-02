using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VeterinarySurgeon.Application.Specifications;
using VeterinarySurgeon.Core.Entities;
using VeterinarySurgeon.Core.Interfaces;

namespace VeterinarySurgeon.Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IAsyncRepository<Employee> _employeeRepository;
        private readonly IAppLogger<EmployeeService> _logger;

        public EmployeeService(IAsyncRepository<Employee> employeeRepository, IAppLogger<EmployeeService> logger)
        {
            _employeeRepository = employeeRepository;
            _logger = logger;
        }

        public async Task<EmployeeDTO> AddPetAsync(ICollection<PetDTO> pets)
        {
            if (!pets.Any())
                return null;

            var employeeId = pets.FirstOrDefault().EmployeeId;
            var spec = new EmployeeWithPetsSpecification(employeeId);

            var employee = await _employeeRepository.FirstOrDefaultAsync(spec);

            if (employee is null)
                return null;

            employee.AddPets(PetDTO.FromPetDTO(pets));

            await _employeeRepository.UpdateAsync(employee);

            return EmployeeDTO.FromEmployee(employee);
        }

        public async Task<bool> Exists(int employeeId)
        {
            var item = await _employeeRepository.GetByIdAsync(employeeId);

            if (item == null)
            {
                _logger.LogWarning($"Employee {employeeId} not exists.");

                return false;
            }

            return true;
        }

        public async Task<EmployeeDTO> GetByIdAsync(int employeeId)
        {
            var spec = new EmployeeWithFamilyMembersSpecification(employeeId);

            var item = await _employeeRepository.FirstOrDefaultAsync(spec);

            if (item == null)
            {
                _logger.LogWarning($"Employee {employeeId} not exists.");

                return null;
            }

            return EmployeeDTO.FromEmployee(item);
        }

        public async Task<ICollection<EmployeeDTO>> ListAsyncPaged(EmployeesPaginatedWithPetsSpecification spec)
        {
            var items = await _employeeRepository.ListAsync(spec);

            return items.Select(x => EmployeeDTO.FromEmployee(x)).ToList();
        }

        public async Task<bool> Delete(int employeeId)
        {
            var itemToDelete = await _employeeRepository.GetByIdAsync(employeeId);

            if (itemToDelete is null) return false;

            await _employeeRepository.DeleteAsync(itemToDelete);

            return true;
        }
    }
}
