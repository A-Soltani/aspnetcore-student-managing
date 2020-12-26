using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace UserManaging.API.Infrastructure.Configuration
{
    public static class ConfigurationServiceExtension
    {
        public static IServiceCollection AddCustomConfigurationService(this IServiceCollection services, IConfiguration configuration)
        {
            var appSettingsSection = configuration.GetSection("AppSettings");
            var appSettings = appSettingsSection.Get<AppSettings>();
            services.Configure<AppSettings>(appSettingsSection);
            services.AddSingleton(appSettings);

            return services;
        }
    }
}