using MediatR;

namespace StudentManaging.Application.Commands
{
    public class AddStudentCommand: IRequest
    {
        public string Name { get; set; }
        //public Address Address { get; set; }
        public string PhoneNumber { get; set; }
    }
}