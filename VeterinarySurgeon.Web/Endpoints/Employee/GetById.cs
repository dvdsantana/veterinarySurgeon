using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;
using VeterinarySurgeon.Application.Services;

namespace VeterinarySurgeon.Web.Endpoints.Employee
{
    public class GetById : BaseAsyncEndpoint<int, EmployeeResponse>
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
        public override async Task<ActionResult<EmployeeResponse>> HandleAsync(int id)
        {
            var item = await _employeeService.GetByIdAsync(id);

            if (item is null)
                return NotFound();

            return Ok(item);
        }
    }
}