using Microsoft.Extensions.DependencyInjection;
using VeterinarySurgeon.Application.Services;

namespace VeterinarySurgeon.Application
{
    public static class StartupSetup
    {
        public static void AddEmployeeService(this IServiceCollection services) =>
            services.AddScoped<IEmployeeService, EmployeeService>();

        public static void AddPetService(this IServiceCollection services) =>
            services.AddScoped<IPetService, PetService>();
    }
}
