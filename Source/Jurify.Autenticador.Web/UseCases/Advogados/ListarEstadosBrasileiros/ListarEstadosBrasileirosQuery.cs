using Jurify.Autenticador.Web.Domain.Model.Enums;
using Jurify.Autenticador.Web.UseCases.Core;
using MediatR;
using System.Collections.Generic;

namespace Jurify.Autenticador.Web.UseCases.Advogados.ListarEstadosBrasileiros
{
    public class ListarEstadosBrasileirosQuery : IRequest<Response<IEnumerable<EstadoBrasileiro>>>
    {
    }
}
