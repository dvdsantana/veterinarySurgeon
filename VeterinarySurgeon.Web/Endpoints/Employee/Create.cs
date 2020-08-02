using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;
using VeterinarySurgeon.Application.Services;

namespace VeterinarySurgeon.Web.Endpoints.Employee
{
    public class Create : BaseAsyncEndpoint<CreateEmployeeRequest, EmployeeResponse>
    {
        private readonly IEmployeeService _employeeService;

        public Create(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpPost("/employees")]
        [SwaggerOperation(
            Summary = "Creates a new Employee",
            Description = "Creates a new Employee",
            OperationId = "Employee.Create",
            Tags = new[] { "EmployeeEndpoints" })
        ]
        public override async Task<ActionResult<EmployeeResponse>> HandleAsync(CreateEmployeeRequest request)
        {
            var employeeCreated = await _employeeService.Create(request.Name, request.LastName);

            if (employeeCreated is null)
                return NotFound();

            return EmployeeResponse.FromEmployeeDTO(employeeCreated);
        }
    }
}
