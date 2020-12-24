using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StudentManaging.Infrastructure.Repositories.EF.StudentManagement;

namespace StudentManaging.API.Infrastructure.CustomExtensions
{
    public static class RegistrationServicesExtension
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<StudentManagementDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("StudentManagementConnection")));

            return services;
        }


    }
}