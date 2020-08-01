using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VeterinarySurgeon.Application.Services;
using VeterinarySurgeon.Application.Specifications;
using VeterinarySurgeon.Web.Endpoints.Pet;

namespace VeterinarySurgeon.Web.Endpoints.Employee
{
    public class List : BaseAsyncEndpoint<List<EmployeeDTO>>
    {
        private readonly IEmployeeService _employeeService;

        public List(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet("/employees")]
        [SwaggerOperation(
            Summary = "Gets a list of all Employees",
            Description = "Gets a list of all Employees",
            OperationId = "Employee.List",
            Tags = new[] { "EmployeeEndpoints" })
        ]
        public override async Task<ActionResult<List<EmployeeDTO>>> HandleAsync()
        {
            var pagedSpecification = new EmployeesPaginatedWithPetsSpecification(skip:0, take:10);
            var items = await _employeeService.ListAsyncPaged(pagedSpecification);

            return Ok(items);
        }
    }
}
