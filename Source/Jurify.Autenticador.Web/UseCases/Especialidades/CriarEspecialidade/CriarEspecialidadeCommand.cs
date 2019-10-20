using Jurify.Autenticador.Web.Domain.Model.Entities;
using Jurify.Autenticador.Web.UseCases.Core;
using Jurify.Autenticador.Web.UseCases.Offices.Create;
using MediatR;

namespace Jurify.Autenticador.Web.UseCases.Specialties.Create
{
    public partial class CriarEspecialidadeCommand : IRequest<Response<Especialidade>>
    {
        public Especialidade Especialidade { get; set; }

        public CriarEspecialidadeCommand()
        {

        }

        public CriarEspecialidadeCommand(Especialidade especialidade)
        {
            especialidade = Especialidade;
        }


    }
}
