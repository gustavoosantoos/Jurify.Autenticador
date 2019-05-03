﻿using Jurify.Autenticador.Web.Domain.Model.Entities;
using Jurify.Autenticador.Web.Domain.Model.ValueObjects;
using Jurify.Autenticador.Web.UseCases.Core;
using Jurify.Autenticador.Web.UseCases.Offices.Create;
using MediatR;
using System;
using System.Collections.Generic;

namespace Jurify.Autenticador.Web.UseCases.Lawyers.CreateInitial
{
    public class CreateInitialLawyerCommand : IRequest<Response<OfficeUser>>
    {
        public string OfficeName { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public string Username { get; set; }
        public string PlainPassword { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public CreateOfficeCommand CreateOfficeCommand =>
            new CreateOfficeCommand()
            {
                OfficeName = OfficeName,
                Latitude = Latitude,
                Longitude = Longitude
            };
    }
}
