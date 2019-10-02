using Jurify.Autenticador.Web.UseCases.Core;
using MediatR;

namespace Jurify.Autenticador.Web.UseCases.Clientes.ListarEscritorios
{
    public class ListarEscritoriosQuery : IRequest<Response<Escritorio[]>>
    {
    }
}
