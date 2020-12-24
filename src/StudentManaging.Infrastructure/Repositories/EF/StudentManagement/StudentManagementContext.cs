
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudentManaging.Domain.AggregatesModel.StudentAggregate;
using StudentManaging.Domain.SeedWork;
using StudentManaging.Infrastructure.Repositories.EF.StudentManagement.EntityConfigurations;

namespace StudentManaging.Infrastructure.Repositories.EF.StudentManagement
{
    public class StudentManagementContext : DbContext, IUnitOfWork
    {
        //public StudentManagementContext(DbContextOptions<StudentManagementContext> options) : base(options)
        //{ }

        public StudentManagementContext(DbContextOptions<StudentManagementContext> options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Address> Address { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StudentEntityTypeConfiguration());
        }

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await base.SaveChangesAsync(cancellationToken);
            return true;
        }
    }

   
}