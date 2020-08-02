using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;
using VeterinarySurgeon.Application.Services;

namespace VeterinarySurgeon.Web.Endpoints.Pet
{
    public class Create : BaseAsyncEndpoint<CreatePetRequest, PetResponse>
    {
        private readonly IPetService _petService;

        public Create(IPetService petService)
        {
            _petService = petService;
        }

        [HttpPost("/pets")]
        [SwaggerOperation(
            Summary = "Creates a new Pet",
            Description = "Creates a new Pet",
            OperationId = "Pet.Create",
            Tags = new[] { "PetEndpoints" })
        ]
        public override async Task<ActionResult<PetResponse>> HandleAsync(CreatePetRequest request)
        {
            var petCreated = await _petService.Create(request.Name, request.AnimalId, request.EmployeeId);

            if (petCreated is null)
                return NotFound();

            return PetResponse.FromPetDTO(petCreated);
        }
    }
}
