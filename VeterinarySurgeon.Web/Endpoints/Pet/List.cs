using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Threading.Tasks;
using VeterinarySurgeon.Application.Services;
using VeterinarySurgeon.Application.Specifications;

namespace VeterinarySurgeon.Web.Endpoints.Pet
{
    public class List : BaseAsyncEndpoint<List<PetResponse>>
    {
        private readonly IPetService _petService;

        public List(IPetService petService)
        {
            _petService = petService;
        }

        [HttpGet("/pets")]
        [SwaggerOperation(
            Summary = "Gets a list of all Pets",
            Description = "Gets a list of all Pets",
            OperationId = "Pet.List",
            Tags = new[] { "PetEndpoints" })
        ]
        public override async Task<ActionResult<List<PetResponse>>> HandleAsync()
        {
            var pagedSpecification = new PetsPaginatedWithOwnerSpecification(skip: 0, take: 10);

            var items = await _petService.ListAsyncPaged(pagedSpecification);

            var response = PetResponse.FromPetDTO(items);

            return Ok(response);
        }
    }
}