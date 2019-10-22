using Jurify.Autenticador.Web.Domain.Model.Entities;
using Jurify.Autenticador.Web.UseCases.Core;
using MediatR;
using System;
using System.Collections.Generic;

namespace Jurify.Autenticador.Web.UseCases.Offices.ListOffices
{
    public class DadosEscritorioQuery : IRequest<Response<Escritorio>>
    {
        public DadosEscritorioQuery(Guid codigoEscritorio)
        {
            CodigoEscritorio = codigoEscritorio;
        }

        public Guid CodigoEscritorio { get; set; }

    }
}
