using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace StudentManaging.API.Infrastructure.CustomExtensions
{
    public static class SwaggerServiceExtension
    {
		public static IServiceCollection AddCustomSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "StudentManaging.API",
                    Version = "v1",
                    Description = "The Student Managing Service API",
                });
            });

            return services;
        }
	}
}