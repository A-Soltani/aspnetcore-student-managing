using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using StudentManaging.Domain.AggregatesModel.StudentAggregate;

namespace StudentManaging.Application.Commands
{
    public class AddStudentCommandHandler: AsyncRequestHandler<AddStudentCommand>
    {
        private readonly IStudentRepository _studentRepository;

        public AddStudentCommandHandler(IStudentRepository studentRepository) => 
            _studentRepository = studentRepository ?? throw new ArgumentNullException(nameof(studentRepository));

        protected override async Task Handle(AddStudentCommand message, CancellationToken cancellationToken)
        {
            var address = Address.AddAddress(message.Street, message.City, message.State, message.Country, message.ZipCode);
            var student = Student.AddStudent(message.Name, address, message.PhoneNumber);

            await _studentRepository.Add(student);
            await _studentRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}