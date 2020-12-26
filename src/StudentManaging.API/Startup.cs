using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using StudentManaging.API.Infrastructure.CustomExtensions;
using StudentManaging.Application.Commands;
using StudentManaging.Infrastructure.Repositories.EF.StudentManagement;
using UserManaging.API.Infrastructure.CustomExtensions;

namespace StudentManaging.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCustomSwagger()
                .AddCustomCors()
                .AuthenticationService(Configuration)
                .AddInfrastructureServices(Configuration)
                .AddMediatR(typeof(AddStudentCommandHandler))
                .AddControllers();

            SeedDb(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(s =>
            {
                s.SwaggerEndpoint("/swagger/v1/swagger.json", "Student Managing API V1");
            });


            app.UseAuthentication();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private static void SeedDb(IServiceCollection services)
        {
            var serviceProvider = services.BuildServiceProvider();
            var studentManagementDb = serviceProvider.GetRequiredService<StudentManagementContext>();
            StudentManagementDbInitializer.Initialize(studentManagementDb);
        }
    }
}
