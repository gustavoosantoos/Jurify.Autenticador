using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Jurify.Autenticador.Web.UseCases.Lawyers.CreateInitial
{
    public class CreateInitialLawyerCommandHandler : IRequestHandler<CreateInitialLawyerCommand>
    {
        public Task<Unit> Handle(CreateInitialLawyerCommand request, CancellationToken cancellationToken)
        {
            return Unit.Task;
        }
    }
}
