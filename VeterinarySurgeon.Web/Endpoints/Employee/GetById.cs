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
    public class GetById : BaseAsyncEndpoint<int, EmployeeResponse>
    {
        private readonly IRepository _repository;

        public GetById(IRepository repository)
        {
            _repository = repository;
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
            var item = await _repository.GetByIdAsync<Core.Entities.Employee>(id);

            var response = new EmployeeResponse
            {
                FamilyMembers = FamilyMemberResponse.FromFamilyMember(item.FamilyMembers),
                Id = item.Id,
                IsEmployee = item.IsEmployee,
                LastName = item.LastName,
                Name = item.Name,
                Pets = PetResponse.FromPet(item.Pets)
            };
            return Ok(response);
        }
    }
}
