using Jurify.Autenticador.Web.Domain.Model.Enums;
using Jurify.Autenticador.Web.UseCases.Core;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Jurify.Autenticador.Web.UseCases.Advogados.ListarEstadosBrasileiros
{
    public class ListarEstadosBrasileirosQueryHandler
        : IRequestHandler<ListarEstadosBrasileirosQuery, Response<IEnumerable<EstadoBrasileiro>>>
    {
        public Task<Response<IEnumerable<EstadoBrasileiro>>> Handle(ListarEstadosBrasileirosQuery request, CancellationToken cancellationToken)
        {
            var estados = EstadoBrasileiro.ObterTodos();
            var response = Response<IEnumerable<EstadoBrasileiro>>.WithResult(estados);
            return Task.FromResult(response);
        }
    }
}
