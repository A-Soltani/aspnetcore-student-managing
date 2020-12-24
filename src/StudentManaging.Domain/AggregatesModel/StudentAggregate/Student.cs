using System.Net.Sockets;
using StudentManaging.Domain.SeedWork;

namespace StudentManaging.Domain.AggregatesModel.StudentAggregate
{
    public class Student : Entity, IAggregateRoot
    {
        public string Name { get; private set; }
        public Address Address { get; private set; }
        public string PhoneNumber { get; private set; }

        private Student(string name, Address address, string phoneNumber)
        {
            Name = name;
            Address = address;
            PhoneNumber = phoneNumber;
        }

        public static Student AddStudent(string name, Address address, string phoneNumber) => 
            new Student(name,address,phoneNumber);
    }
}