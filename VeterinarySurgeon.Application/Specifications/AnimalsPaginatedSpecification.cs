using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Text;
using VeterinarySurgeon.Core.Entities;

namespace VeterinarySurgeon.Application.Specifications
{
    public class AnimalsPaginatedSpecification : Specification<Animal>
    {
        public AnimalsPaginatedSpecification(int skip, int take)
        {
            Query.Paginate(skip, take);
        }
    }
}
