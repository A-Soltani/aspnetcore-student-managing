using System;
using System.Threading.Tasks;
using StudentManaging.Domain.AggregatesModel.StudentAggregate;
using StudentManaging.Domain.SeedWork;

namespace StudentManaging.Infrastructure.Repositories.EF.StudentManagement
{
    public class StudentRepository: IStudentRepository
    {
        private readonly StudentManagementContext _context;

        public IUnitOfWork UnitOfWork => _context;

        public StudentRepository(StudentManagementContext context) => 
            _context = context ?? throw new ArgumentNullException(nameof(context));

        public async Task<Student> Add(Student currency) => 
            (await _context.Students.AddAsync(currency)).Entity;
    }
}