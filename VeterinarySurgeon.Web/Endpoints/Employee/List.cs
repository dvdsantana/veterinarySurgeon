using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VeterinarySurgeon.SharedKernel.Interfaces;
using VeterinarySurgeon.Web.Endpoints.Pet;

namespace VeterinarySurgeon.Web.Endpoints.Employee
{
    public class List : BaseAsyncEndpoint<List<EmployeeResponse>>
    {
        private readonly IRepository _repository;

        public List(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("/employees")]
        [SwaggerOperation(
            Summary = "Gets a list of all Employees",
            Description = "Gets a list of all Employees",
            OperationId = "Employee.List",
            Tags = new[] { "EmployeeEndpoints" })
        ]
        public override async Task<ActionResult<List<EmployeeResponse>>> HandleAsync()
        {
            var items = (await _repository.ListAsync<Core.Entities.Employee>())
                .Select(item => new EmployeeResponse
                {
                    FamilyMembers = FamilyMemberResponse.FromFamilyMember(item.FamilyMembers),
                    Id = item.Id,
                    IsEmployee = item.IsEmployee,
                    LastName = item.LastName,
                    Name = item.Name,
                    Pets = PetResponse.FromPet(item.Pets)
                });

            return Ok(items);
        }
    }
}
