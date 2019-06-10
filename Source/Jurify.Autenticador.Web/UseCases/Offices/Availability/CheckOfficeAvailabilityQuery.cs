using Jurify.Autenticador.Web.UseCases.Core;
using MediatR;

namespace Jurify.Autenticador.Web.UseCases.Offices.Availability
{
    public class CheckOfficeAvailabilityQuery : IRequest<Response<bool>>
    {
        public CheckOfficeAvailabilityQuery(string officeName)
        {
            OfficeName = officeName;
        }

        public CheckOfficeAvailabilityQuery() { }

        public string OfficeName { get; set; }
    }
}
