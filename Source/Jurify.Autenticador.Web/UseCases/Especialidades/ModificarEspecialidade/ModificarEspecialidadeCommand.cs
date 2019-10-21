using Jurify.Autenticador.Web.Domain.Model.Entities;
using Jurify.Autenticador.Web.UseCases.Core;
using Jurify.Autenticador.Web.UseCases.Offices.Create;
using MediatR;
using System;

namespace Jurify.Autenticador.Web.UseCases.Specialties.Create
{
    public partial class ModificarEspecialidadeCommand : IRequest<Response<Especialidade>>
    {
        public Guid CodigoEspecialidade { get; set; }
        public Especialidade Especialidade { get; set; }

        public ModificarEspecialidadeCommand()
        {

        }

        public ModificarEspecialidadeCommand(Guid codigoEspecialidade,Especialidade especialidade)
        {
            especialidade = Especialidade;
            CodigoEspecialidade=codigoEspecialidade;
        }


    }
}
