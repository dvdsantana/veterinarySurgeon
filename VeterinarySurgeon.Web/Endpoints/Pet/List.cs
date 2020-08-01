using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VeterinarySurgeon.Web.Endpoints.Animal;
using VeterinarySurgeon.Web.Endpoints.Employee;

namespace VeterinarySurgeon.Web.Endpoints.Pet
{
    //public class List : BaseAsyncEndpoint<List<PetResponse>>
    //{
    //    //private readonly IRepository _repository;

    //    //public List(IRepository repository)
    //    //{
    //    //    _repository = repository;
    //    //}

    //    //[HttpGet("/pets")]
    //    //[SwaggerOperation(
    //    //    Summary = "Gets a list of all Pets",
    //    //    Description = "Gets a list of all Pets",
    //    //    OperationId = "Pet.List",
    //    //    Tags = new[] { "PetEndpoints" })
    //    //]
    //    //public override async Task<ActionResult<List<PetResponse>>> HandleAsync()
    //    //{
    //    //    var items = (await _repository.ListAsync<Core.Entities.Pet>());


    //    //        items.Select(item => new PetResponse
    //    //        {
    //    //            Animal = AnimalResponse.FromAnimal(item.Animal),
    //    //            Id = item.Id,
    //    //            Name = item.Name,
    //    //            Owner = EmployeeResponse.FromEmployee(item.Owner)
    //    //        });

    //    //    return Ok(items);
    //    //}
    //}
}
