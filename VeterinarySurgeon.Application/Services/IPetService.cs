using System.Collections.Generic;
using System.Threading.Tasks;
using VeterinarySurgeon.Application.Specifications;

namespace VeterinarySurgeon.Application.Services
{
    public interface IPetService
    {
        Task<PetDTO> Create(string name, int animalId, int employeeId);

        Task<ICollection<PetDTO>> ListAsyncPaged(PetsPaginatedWithOwnerSpecification spec);

        Task<bool> Delete(int petId);
    }
}