using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VeterinarySurgeon.Web.Endpoints.Animal
{
    //public class List: BaseAsyncEndpoint<List<AnimalResponse>>
    //{
    //    //private readonly IRepository _repository;

    //    //public List(IRepository repository)
    //    //{
    //    //    _repository = repository;
    //    //}

    //    //[HttpGet("/animals")]
    //    //[SwaggerOperation(
    //    //    Summary = "Gets a list of all Animals",
    //    //    Description = "Gets a list of all Animals",
    //    //    OperationId = "Animal.List",
    //    //    Tags = new[] { "AnimalEndpoints" })
    //    //]
    //    //public override async Task<ActionResult<List<AnimalResponse>>> HandleAsync()
    //    //{
    //    //    var items = (await _repository.ListAsync<Core.Entities.Animal>())
    //    //        .Select(item => new AnimalResponse
    //    //        {
    //    //            Name = item.Name
    //    //        });

    //    //    return Ok(items);
    //    //}
    //}
}
