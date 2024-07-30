using Microsoft.Extensions.DependencyInjection;

namespace TestAPI.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection SetupCorsAny(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(
                    "AllowedOrigins",
                    builder =>
                    {
                        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                    }
                );
            });

            return services;
        }
    }
}
