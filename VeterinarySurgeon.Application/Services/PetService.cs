using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VeterinarySurgeon.Application.Specifications;
using VeterinarySurgeon.Core.Entities;
using VeterinarySurgeon.Core.Interfaces;

namespace VeterinarySurgeon.Application.Services
{
    public class PetService : IPetService
    {
        private readonly IAsyncRepository<Pet> _petRepository;
        private readonly IAsyncRepository<Employee> _employeeRepository;
        private readonly IAsyncRepository<Animal> _animalRepository;
        private readonly IAppLogger<EmployeeService> _logger;

        public PetService(
            IAsyncRepository<Pet> petRepository,
            IAsyncRepository<Employee> employeeRepository,
            IAsyncRepository<Animal> animalRepository,
            IAppLogger<EmployeeService> logger)
        {
            _petRepository = petRepository;
            _employeeRepository = employeeRepository;
            _animalRepository = animalRepository;
            _logger = logger;
        }

        public async Task<PetDTO> Create(string name, int animalId, int employeeId)
        {
            var animal = await _animalRepository.GetByIdAsync(animalId);

            if (animal is null) return null;

            var employee = await _employeeRepository.GetByIdAsync(employeeId);

            if (employee is null) return null;

            var petCreated = await _petRepository.AddAsync(new Pet(name, animal, employee));

            var result = PetDTO.FromPet(petCreated);

            return result;
        }

        public async Task<ICollection<PetDTO>> ListAsyncPaged(PetsPaginatedWithOwnerSpecification spec)
        {
            var items = await _petRepository.ListAsync(spec);

            return items.Select(x => PetDTO.FromPet(x)).ToList();
        }
    }
}