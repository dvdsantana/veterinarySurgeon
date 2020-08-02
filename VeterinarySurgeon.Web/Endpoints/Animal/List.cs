using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VeterinarySurgeon.Application.Services;
using VeterinarySurgeon.Application.Specifications;

namespace VeterinarySurgeon.Web.Endpoints.Animal
{
    public class List : BaseAsyncEndpoint<List<AnimalResponse>>
    {
        private readonly IAnimalService _animalService;

        public List(IAnimalService animalService)
        {
            _animalService = animalService;
        }

        [HttpGet("/animals")]
        [SwaggerOperation(
            Summary = "Gets a list of all Animals",
            Description = "Gets a list of all Animals",
            OperationId = "Animal.List",
            Tags = new[] { "AnimalEndpoints" })
        ]
        public override async Task<ActionResult<List<AnimalResponse>>> HandleAsync()
        {
            var pagedSpecification = new AnimalsPaginatedSpecification(skip: 0, take: 10);

            var items = await _animalService.ListAsyncPaged(pagedSpecification);

            var response = AnimalResponse.FromAnimalDTO(items);

            return Ok(response);
        }
    }
}
