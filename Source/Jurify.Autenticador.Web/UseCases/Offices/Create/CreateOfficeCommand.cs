using MediatR;
using System;

namespace Jurify.Autenticador.Web.UseCases.Offices.Create
{
    public class CreateOfficeCommand : IRequest<Guid>
    {
        public string OfficeName { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
