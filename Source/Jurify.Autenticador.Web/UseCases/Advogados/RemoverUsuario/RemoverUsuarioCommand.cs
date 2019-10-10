using Jurify.Autenticador.Web.Domain.Model.Entities;
using Jurify.Autenticador.Web.UseCases.Core;
using Jurify.Autenticador.Web.UseCases.Offices.Create;
using MediatR;
using System;

namespace Jurify.Autenticador.Web.UseCases.Lawyers.CreateInitial
{
    public partial class RemoverUsuarioCommand : IRequest<Response<UsuarioEscritorio>>
    {
        public Guid CodigoUsuario { get; set; }

        public RemoverUsuarioCommand()
        {
        }

        public RemoverUsuarioCommand(Guid codigoUsuario)
        {
            CodigoUsuario = codigoUsuario;
        }


    }
}
