
using Microsoft.EntityFrameworkCore;
using StudentManaging.Domain.AggregatesModel.StudentAggregate;

namespace StudentManaging.Infrastructure.Repositories.EF.StudentManagement
{
    public class StudentManagementDbContext : DbContext
    {
        public StudentManagementDbContext(DbContextOptions<StudentManagementDbContext> options) : base(options)
        { }

        public DbSet<Student> Students { get; set; }
        public DbSet<Address> Address { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().ToTable("Student");
            modelBuilder.Entity<Address>().ToTable("Address");
        }
    }
}