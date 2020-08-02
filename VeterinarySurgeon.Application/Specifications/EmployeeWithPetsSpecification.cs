using Ardalis.Specification;
using VeterinarySurgeon.Core.Entities;

namespace VeterinarySurgeon.Application.Specifications
{
    public class EmployeeWithPetsSpecification : Specification<Employee>
    {
        public EmployeeWithPetsSpecification(int employeeId)
        {
            Query.Where(x => x.IsEmployee == true && x.Id == employeeId)
                .Include(e => e.Pets)
                    .ThenInclude(a => a.Animal);
        }
    }
}