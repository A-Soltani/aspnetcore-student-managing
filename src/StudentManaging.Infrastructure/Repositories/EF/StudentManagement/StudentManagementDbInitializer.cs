using System;
using System.Linq;
using StudentManaging.Domain.AggregatesModel.StudentAggregate;

namespace StudentManaging.Infrastructure.Repositories.EF.StudentManagement
{
    public class StudentManagementDbInitializer
    {
        public static void Initialize(StudentManagementContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Students.Any())
            {
                return;   // DB has been seeded
            }

            var address = Address.AddAddress("Khayyam", "Tehran", "Tehran", "Iran", "1234567890");
            var student = Student.AddStudent("Majid Parsa", address, "00989122112567");
            context.Students.Add(student);

            context.SaveChanges();
        }
    }
}