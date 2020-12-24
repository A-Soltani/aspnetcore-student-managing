using MediatR;

namespace StudentManaging.Application.Commands
{
    public class AddStudentCommand : IRequest
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
    }
}