using Jurify.Autenticador.Web.Domain.Model.Entities;
using Jurify.Autenticador.Web.UseCases.Core;
using Jurify.Autenticador.Web.UseCases.Offices.Create;
using MediatR;

namespace Jurify.Autenticador.Web.UseCases.Lawyers.CreateInitial
{
    public partial class CriarUsuarioNovoCommand : IRequest<Response<UsuarioEscritorio>>
    {
        public Usuario Usuario { get; set; }
        public Escritorio Escritorio { get; set; }

        public CriarUsuarioNovoCommand()
        {
        }

        public CriarUsuarioNovoCommand(Usuario usuario, Escritorio escritorio)
        {
            Usuario = usuario;
            Escritorio = escritorio;
        }


    }
}
