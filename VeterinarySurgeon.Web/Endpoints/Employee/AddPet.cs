namespace VeterinarySurgeon.Web.Endpoints.Employee
{
    //public class AddPet : BaseAsyncEndpoint<AddPetRequest, EmployeeDTO>
    //{
    //    private readonly IEmployeeService _employeeService;

    //    public AddPet(IEmployeeService employeeService)
    //    {
    //        _employeeService = employeeService;
    //    }

    //    [HttpPut("/employees")]
    //    [SwaggerOperation(
    //        Summary = "Add a new pet to employee",
    //        Description = "Updates a Employee adding a new pet to it's collection",
    //        OperationId = "Employee.AddPet",
    //        Tags = new[] { "EmployeeEndpoints" })
    //    ]
    //    public override async Task<ActionResult<EmployeeDTO>> HandleAsync(AddPetRequest request)
    //    {
    //        var existingItem = await _employeeService.Exists(request.EmployeeId);

    //        if (!existingItem)
    //            return NotFound();

    //    }
    //}
}
