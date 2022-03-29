using Application.Abstractions.Providers;
using Infrastructure.Employees;
using Infrastructure.Employees.Maps;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(EmployeeProfile));

            services.AddScoped<IEmployeeProvider, MockDataProvider>();
            services.AddScoped<IEmployeeProvider, LiveDataProvider>();

            return services;
        }
    }
}
