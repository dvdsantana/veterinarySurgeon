using System.Collections.Generic;
using System.Threading.Tasks;
using VeterinarySurgeon.Application.Specifications;

namespace VeterinarySurgeon.Application.Services
{
    public interface IAnimalService
    {
        Task<ICollection<AnimalDTO>> ListAsyncPaged(AnimalsPaginatedSpecification spec);
    }
}