using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VeterinarySurgeon.Application.Specifications;
using VeterinarySurgeon.Core.Entities;
using VeterinarySurgeon.Core.Interfaces;

namespace VeterinarySurgeon.Application.Services
{
    public class AnimalService : IAnimalService
    {
        private readonly IAsyncRepository<Animal> _animalRepository;

        public AnimalService(IAsyncRepository<Animal> animalRepository)
        {
            _animalRepository = animalRepository;
        }

        public async Task<ICollection<AnimalDTO>> ListAsyncPaged(AnimalsPaginatedSpecification spec)
        {
            var items = await _animalRepository.ListAsync(spec);

            return items.Select(x => AnimalDTO.FromAnimal(x)).ToList();
        }
    }
}