using Microsoft.Extensions.DependencyInjection;

namespace StudentManaging.API.Infrastructure.CustomExtensions
{
    public static class CorsServiceExtension
    {
		public static IServiceCollection AddCustomCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder
                        .SetIsOriginAllowed((host) => true)
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials());
            });

            return services;
        }
	}
}