using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;
using VeterinarySurgeon.Application.Services;

namespace VeterinarySurgeon.Web.Endpoints.Pet
{
    public class Delete : BaseAsyncEndpoint<int, PetResponse>
    {
        private readonly IPetService _petService;

        public Delete(IPetService petService)
        {
            _petService = petService;
        }

        [HttpDelete("/pets/{id:int}")]
        [SwaggerOperation(
            Summary = "Delete a Pet",
            Description = "Delete a Pet",
            OperationId = "Pet.Delete",
            Tags = new[] { "PetEndpoints" })
        ]
        public override async Task<ActionResult<PetResponse>> HandleAsync(int id)
        {
            var isDeleted = await _petService.Delete(id);

            if (!isDeleted)
                return NotFound();

            return NoContent();
        }
    }
}
