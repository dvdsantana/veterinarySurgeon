using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;
using VeterinarySurgeon.Web.Endpoints.Animal;
using VeterinarySurgeon.Web.Endpoints.Employee;

namespace VeterinarySurgeon.Web.Endpoints.Pet
{
    //public class GetById : BaseAsyncEndpoint<int, PetResponse>
    //{
    //    //private readonly IRepository _repository;

    //    //public GetById(IRepository repository)
    //    //{
    //    //    _repository = repository;
    //    //}

    //    //[HttpGet("/pets/{id:int}")]
    //    //[SwaggerOperation(
    //    //    Summary = "Gets a single Pet",
    //    //    Description = "Gets a single Pet by Id",
    //    //    OperationId = "Pet.GetById",
    //    //    Tags = new[] { "PetEndpoints" })
    //    //]
    //    //public override async Task<ActionResult<PetResponse>> HandleAsync(int id)
    //    //{
    //    //    var item = await _repository.GetByIdAsync<Core.Entities.Pet>(id);

    //    //    var response = new PetResponse
    //    //    {
    //    //        Animal = AnimalResponse.FromAnimal(item.Animal),
    //    //        Id = item.Id,
    //    //        Name = item.Name,
    //    //        Owner = EmployeeResponse.FromEmployee(item.Owner)
    //    //    };
    //    //    return Ok(response);
    //    //}
    //}
}
