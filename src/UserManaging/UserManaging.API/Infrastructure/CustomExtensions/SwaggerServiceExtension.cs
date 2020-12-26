using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace UserManaging.API.Infrastructure.CustomExtensions
{
    public static class SwaggerServiceExtension
    {
		public static IServiceCollection AddCustomSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "UserManaging.API",
                    Version = "v1",
                    Description = "The user Managing Service API",
                });
            });

            return services;
        }
	}
}