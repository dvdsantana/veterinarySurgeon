using Ardalis.Specification;
using VeterinarySurgeon.Core.Entities;

namespace VeterinarySurgeon.Application.Specifications
{
    public class EmployeeWithFamilyMembersSpecification : Specification<Employee>
    {
        public EmployeeWithFamilyMembersSpecification(int employeeId)
        {
            Query.Where(x => x.IsEmployee == true && x.Id == employeeId)
                .Include(e => e.FamilyMembers)
                    .ThenInclude(f => f.Pets)
                        .ThenInclude(p => p.Animal);
            
            Query.Include(e => e.Pets)
                .ThenInclude(p => p.Animal);
        }
    }
}
