using Microsoft.Extensions.DependencyInjection;
using UserManaging.API.Services.Authentication;

namespace UserManaging.API.Infrastructure.CustomExtensions
{
    public static class RegistrationServicesExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            return services;
        }

    }
}