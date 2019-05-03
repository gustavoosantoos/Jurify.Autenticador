using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Jurify.Autenticador.Web.UseCases.Offices.Create
{
    public class CreateOfficeCommandHandler : IRequestHandler<CreateOfficeCommand, Guid>
    {
        public async Task<Guid> Handle(CreateOfficeCommand request, CancellationToken cancellationToken)
        {
            return Guid.Empty;
        }
    }
}
