using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Jurify.Autenticador.Web.UseCases.Offices.Create
{
    public class CreateOfficeCommandHandler : IRequestHandler<CreateOfficeCommand>
    {
        public Task<Unit> Handle(CreateOfficeCommand request, CancellationToken cancellationToken)
        {
            return Unit.Task;
        }
    }
}
