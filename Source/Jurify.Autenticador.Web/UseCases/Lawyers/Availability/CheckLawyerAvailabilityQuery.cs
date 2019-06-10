using Jurify.Autenticador.Web.UseCases.Core;
using MediatR;

namespace Jurify.Autenticador.Web.UseCases.Lawyers.Availability
{
    public class CheckLawyerAvailabilityQuery : IRequest<Response<bool>>
    {
        public CheckLawyerAvailabilityQuery(string username)
        {
            Username = username;
        }

        public CheckLawyerAvailabilityQuery() { }

        public string Username { get; set; }
    }
}
