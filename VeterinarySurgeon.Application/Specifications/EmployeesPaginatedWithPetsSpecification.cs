using Ardalis.Specification;
using VeterinarySurgeon.Core.Entities;

namespace VeterinarySurgeon.Application.Specifications
{
    public class EmployeesPaginatedWithPetsSpecification : Specification<Employee>
    {
        public EmployeesPaginatedWithPetsSpecification(int skip, int take)
        {
            Query.Where(x => x.IsEmployee == true)
                .Paginate(skip, take)
                .Include(e => e.Pets)
                    .ThenInclude(p => p.Animal);
            
            Query.Include(e => e.FamilyMembers)
                .ThenInclude(f => f.Pets)
                    .ThenInclude(p => p.Animal);
        } 
    }
}
