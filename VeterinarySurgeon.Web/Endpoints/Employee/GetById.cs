using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using VeterinarySurgeon.Application.Services;
using VeterinarySurgeon.Application.Specifications;
using VeterinarySurgeon.Web.Endpoints.Pet;

namespace VeterinarySurgeon.Web.Endpoints.Employee
{
    public class GetById : BaseAsyncEndpoint<int, EmployeeDTO>
    {
        private readonly IEmployeeService _employeeService;

        public GetById(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet("/employees/{id:int}")]
        [SwaggerOperation(
            Summary = "Gets a single Employee",
            Description = "Gets a single Employee by Id",
            OperationId = "Employee.GetById",
            Tags = new[] { "EmployeeEndpoints" })
        ]
        public override async Task<ActionResult<EmployeeDTO>> HandleAsync(int id)
        {
            
            var item = await _employeeService.GetById(id);
            return Ok(item);
        }
    }
}
