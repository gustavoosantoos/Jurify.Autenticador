using Jurify.Autenticador.Web.Domain.Model.Entities;
using Jurify.Autenticador.Web.UseCases.Core;
using MediatR;
using System;

namespace Jurify.Autenticador.Web.UseCases.Specialties.RemoveOfficeSpecialty
{
    public class RemoverEspecialidadeEscritorioCommand : IRequest<Response<EspecialidadesEscritorio>>
    {
        public Guid CodigoEspecialidadeEscritorio { get; set; }

        public RemoverEspecialidadeEscritorioCommand()
        {

        }

        public RemoverEspecialidadeEscritorioCommand(Guid codigoEspecialidadeEscritorio)
        {
            CodigoEspecialidadeEscritorio = codigoEspecialidadeEscritorio;
        }

    }
}
