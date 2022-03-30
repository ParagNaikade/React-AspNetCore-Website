using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Server
{
    internal static class CorsExtensions
    {
        private static readonly string UnityCorsName = "Cors";

        public static IServiceCollection AddCors(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddCors(o => o.AddPolicy(UnityCorsName, builder =>
            {
                builder.WithOrigins(configuration.GetSection("CorsList").Get<string[]>())
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            }));
            return services;
        }

        public static IApplicationBuilder UseCors(this IApplicationBuilder application)
        {
            application.UseCors(UnityCorsName);
            return application;
        }
    }
}
