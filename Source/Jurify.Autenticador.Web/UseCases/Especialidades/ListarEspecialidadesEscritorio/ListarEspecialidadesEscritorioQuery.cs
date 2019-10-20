
using Jurify.Autenticador.Web.Domain.Model.Entities;
using Jurify.Autenticador.Web.UseCases.Advogados.ListarUsuariosDoEscritorio;
using Jurify.Autenticador.Web.UseCases.Core;
using MediatR;
using System;
using System.Collections.Generic;

namespace Jurify.Autenticador.Web.UseCases.Specialties.ListSpecialties
{
    public class ListarEspecialidadesEscritorioQuery : IRequest<Response<List<EspecialidadesEscritorio>>>
    {
        public ListarEspecialidadesEscritorioQuery(Guid codigoEcritorio)
        {
            CodigoEscritorio = codigoEcritorio;
        }

        public Guid CodigoEscritorio { get; set; }

    }
}
