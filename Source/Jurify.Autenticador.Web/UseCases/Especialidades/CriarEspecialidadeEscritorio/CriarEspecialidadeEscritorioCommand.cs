
using Jurify.Autenticador.Web.Domain.Model.Entities;
using Jurify.Autenticador.Web.UseCases.Core;
using Jurify.Autenticador.Web.UseCases.Offices.Create;
using MediatR;
using System;


namespace Jurify.Autenticador.Web.UseCases.Specialties.CreateOfficeSpecialty
{
    public partial class CriarEspecialidadeEscritorioCommand : IRequest<Response<EspecialidadesEscritorio>>
    {
        public Guid CodigoEspecialidade { get;  set; }
        public Guid CodigoEscritorio { get;  set; }

        public CriarEspecialidadeEscritorioCommand(Guid codigoEspecialidade, Guid codigoEscritorio)
        {
            CodigoEspecialidade = codigoEspecialidade;
            CodigoEscritorio = codigoEscritorio;
        }

    }
}
