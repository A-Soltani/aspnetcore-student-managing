
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudentManaging.Domain.AggregatesModel.StudentAggregate;
using StudentManaging.Domain.SeedWork;

namespace StudentManaging.Infrastructure.Repositories.EF.StudentManagement
{
    public class StudentManagementContext : DbContext, IUnitOfWork
    {
        public StudentManagementContext(DbContextOptions<StudentManagementContext> options) : base(options)
        { }

        public DbSet<Student> Students { get; set; }
        public DbSet<Address> Address { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().ToTable("Student");
            modelBuilder.Entity<Address>().ToTable("Address");
        }

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await base.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}