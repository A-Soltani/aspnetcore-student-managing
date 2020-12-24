using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentManaging.Domain.AggregatesModel.StudentAggregate;

namespace StudentManaging.Infrastructure.Repositories.EF.StudentManagement.EntityConfigurations
{
    public class StudentEntityTypeConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("Student")
                .HasKey(s => s.Id);
            builder.OwnsOne(s => s.Address, a =>
                {
                    a.WithOwner();
                });
        }
    }
}