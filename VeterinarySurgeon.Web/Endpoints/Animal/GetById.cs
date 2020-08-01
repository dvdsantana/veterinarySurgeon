using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

namespace VeterinarySurgeon.Web.Endpoints.Animal
{
    //public class GetById : BaseAsyncEndpoint<int, AnimalResponse>
    //{
    //    //private readonly IRepository _repository;

    //    //public GetById(IRepository repository)
    //    //{
    //    //    _repository = repository;
    //    //}

    //    //[HttpGet("/animals/{id:int}")]
    //    //[SwaggerOperation(
    //    //    Summary = "Gets a single Animal",
    //    //    Description = "Gets a single Animal by Id",
    //    //    OperationId = "Animal.GetById",
    //    //    Tags = new[] { "AnimalEndpoints" })
    //    //]
    //    //public override async Task<ActionResult<AnimalResponse>> HandleAsync(int id)
    //    //{
    //    //    var item = await _repository.GetByIdAsync<Core.Entities.Animal>(id);

    //    //    var response = new AnimalResponse
    //    //    {
    //    //        Name = item.Name
    //    //    };
    //    //    return Ok(response);
    //    //}
    //}
}
