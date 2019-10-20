using Jurify.Autenticador.Web.Domain.Model.Entities;
using Jurify.Autenticador.Web.UseCases.Core;
using MediatR;
using Usuario = Jurify.Autenticador.Web.UseCases.Lawyers.CreateInitial.Usuario;

namespace Jurify.Autenticador.Web.UseCases.Lawyers.Modify
{
    public partial class ModificarUsuarioCommand : IRequest<Response<UsuarioEscritorio>>
    {
        public Usuario Usuario { get; set; }

        public ModificarUsuarioCommand()
        {
        }

        public ModificarUsuarioCommand(Usuario usuario)
        {
            Usuario = usuario;
        }


    }
}
