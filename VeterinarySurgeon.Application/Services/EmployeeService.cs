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

        public async Task<EmployeeDTO> GetById(int employeeId)
        {
            var spec = new EmployeeWithFamilyMembersSpecification(employeeId);

            var item = await _employeeRepository.FirstAsync(spec);

            return EmployeeDTO.FromEmployee(item);
        }

        public async Task<ICollection<EmployeeDTO>> ListAsyncPaged(EmployeesPaginatedWithPetsSpecification spec)
        {
            var items = await _employeeRepository.ListAsync(spec);

            return items.Select(x => EmployeeDTO.FromEmployee(x)).ToList();
        }
    }
}
