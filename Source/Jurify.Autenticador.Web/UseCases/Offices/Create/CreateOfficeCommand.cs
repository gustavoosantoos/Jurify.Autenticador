using Jurify.Autenticador.Web.Domain.Model.Entities;
using Jurify.Autenticador.Web.Domain.Model.ValueObjects;
using Jurify.Autenticador.Web.UseCases.Core;
using MediatR;
using System;

namespace Jurify.Autenticador.Web.UseCases.Offices.Create
{
    public class CreateOfficeCommand : IRequest<Response<Guid>>
    {
        public string OfficeName { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public Office AsOffice()
        {
            return new Office(
                new OfficeInfo(OfficeName),
                new OfficeLocation(Latitude, Longitude)
            );
        }
    }
}
