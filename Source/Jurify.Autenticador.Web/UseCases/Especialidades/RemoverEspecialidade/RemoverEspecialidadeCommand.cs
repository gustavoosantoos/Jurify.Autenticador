using Jurify.Autenticador.Web.Domain.Model.Entities;
using Jurify.Autenticador.Web.UseCases.Core;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jurify.Autenticador.Web.UseCases.Specialties.RemoveSpecialty
{
    public class RemoverEspecialidadeCommand : IRequest<Response<Especialidade>>
    {
        public Guid CodigoEspecialidade { get; set; }

        public RemoverEspecialidadeCommand()
        {

        }

        public RemoverEspecialidadeCommand(Guid codigoEspecialidade)
        {
            CodigoEspecialidade = codigoEspecialidade;
        }

    }
}
