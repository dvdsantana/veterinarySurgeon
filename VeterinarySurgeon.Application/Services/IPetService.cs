using System.Threading.Tasks;

namespace VeterinarySurgeon.Application.Services
{
    public interface IPetService
    {
        Task<PetDTO> Create(string name, int animalId, int employeeId);
    }
}