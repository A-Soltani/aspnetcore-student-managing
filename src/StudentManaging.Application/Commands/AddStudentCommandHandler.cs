using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace StudentManaging.Application.Commands
{
    public class AddStudentCommandHandler: AsyncRequestHandler<AddStudentCommand>
    {
        protected override async Task Handle(AddStudentCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}