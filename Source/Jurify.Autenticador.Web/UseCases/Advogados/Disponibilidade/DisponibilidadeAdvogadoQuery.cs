using Jurify.Autenticador.Web.UseCases.Core;
using MediatR;

namespace Jurify.Autenticador.Web.UseCases.Lawyers.Availability
{
    public class DisponibilidadeAdvogadoQuery : IRequest<Response<bool>>
    {
        public DisponibilidadeAdvogadoQuery(string username)
        {
            Username = username;
        }

        public DisponibilidadeAdvogadoQuery() { }

        public string Username { get; set; }
    }
}
