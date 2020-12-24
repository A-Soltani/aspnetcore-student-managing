using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StudentManaging.Domain.AggregatesModel.StudentAggregate;
using StudentManaging.Infrastructure.Repositories.EF.StudentManagement;

namespace StudentManaging.API.Infrastructure.CustomExtensions
{
    public static class RegistrationServicesExtension
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<StudentManagementContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("StudentManagementConnection")));

            services.AddScoped<IStudentRepository, StudentRepository>();

            return services;
        }


    }
}