using Jurify.Autenticador.Web.UseCases.Core;
using MediatR;

namespace Jurify.Autenticador.Web.UseCases.Offices.Availability
{
    public class DisponibilidadeEscritorioQuery : IRequest<Response<bool>>
    {
        public DisponibilidadeEscritorioQuery(string nomeFantasia)
        {
            NomeFantasia = nomeFantasia;
        }

        public DisponibilidadeEscritorioQuery() { }

        public string NomeFantasia { get; set; }
    }
}
