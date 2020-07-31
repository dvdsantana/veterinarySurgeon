using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using VeterinarySurgeon.Infrastructure.Data;
using VeterinarySurgeon.SharedKernel.Interfaces;

namespace VeterinarySurgeon.Infrastructure
{
    public static class StartupSetup
    {
        // extension method to add DB context to service container.
        // will be created in web project root
        public static void AddDbContext(this IServiceCollection services, string connectionString) =>
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlite(connectionString));

        public static void AddEFRepository(this IServiceCollection services) =>
            services.AddScoped<IRepository, EfRepository>();
    }
}
