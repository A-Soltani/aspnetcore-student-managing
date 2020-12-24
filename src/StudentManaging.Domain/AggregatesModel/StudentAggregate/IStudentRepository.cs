using System.Threading.Tasks;
using StudentManaging.Domain.SeedWork;

namespace StudentManaging.Domain.AggregatesModel.StudentAggregate
{
    public interface IStudentRepository : IRepository<Student>
    {
        Task<Student> Add(Student currency);
    }

}