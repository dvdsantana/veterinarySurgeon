using Ardalis.Specification;
using VeterinarySurgeon.Core.Entities;

namespace VeterinarySurgeon.Application.Specifications
{
    public class PetsPaginatedWithOwnerSpecification : Specification<Pet>
    {
        public PetsPaginatedWithOwnerSpecification(int skip, int take)
        {
            Query.Paginate(skip, take)
                .Include(p => p.Animal);

            Query.Include(p => p.Owner);
        }
        
    }
}
