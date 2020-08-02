using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;
using VeterinarySurgeon.Application.Services;
using VeterinarySurgeon.Web.Endpoints.Pet;

namespace VeterinarySurgeon.Web.Endpoints.Employee
{
    public class Update : BaseAsyncEndpoint<UpdateEmployeeRequest, EmployeeResponse>
    {
        private readonly IEmployeeService _employeeService;

        public Update(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpPut("/employees")]
        [SwaggerOperation(
            Summary = "Updates ONLY the Employee pets",
            Description = "Updates a Employee with pets",
            OperationId = "Employee.Update",
            Tags = new[] { "EmployeeEndpoints" })
        ]
        public override async Task<ActionResult<EmployeeResponse>> HandleAsync(UpdateEmployeeRequest request)
        {
            var employee = await _employeeService.AddPetAsync(CreatePetRequest.FromPetRequest(request.Pets));

            if (employee is null)
                return NotFound();

            return EmployeeResponse.FromEmployeeDTO(employee);
        }
    }
}