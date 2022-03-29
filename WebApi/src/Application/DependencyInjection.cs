using Application.Abstractions.Providers;
using Application.Abstractions.Services;
using Application.EmployeeDataProvider;
using Application.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IEmployeeService, EmployeeService>();

            services.AddScoped<IEmployeeProviderFactory, EmployeeDataProviderFactory>();

            return services;
        }
    }
}
