using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;
using VeterinarySurgeon.Application.Services;

namespace VeterinarySurgeon.Web.Endpoints.Employee
{
    public class Delete : BaseAsyncEndpoint<int, EmployeeResponse>
    {
        private readonly IEmployeeService _employeeService;

        public Delete(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpDelete("/employees/{id:int}")]
        [SwaggerOperation(
            Summary = "Deletes a Employee",
            Description = "Deletes a Employee",
            OperationId = "Employee.Delete",
            Tags = new[] { "EmployeeEndpoints" })
        ]
        public override async Task<ActionResult<EmployeeResponse>> HandleAsync(int id)
        {
            var isDeleted = await _employeeService.Delete(id);

            if (!isDeleted)
                return NotFound();

            return NoContent();
        }
    }
}
