using Jurify.Autenticador.Web.Domain.Model.Entities;
using Jurify.Autenticador.Web.UseCases.Core;
using Jurify.Autenticador.Web.UseCases.Offices.Create;
using MediatR;

namespace Jurify.Autenticador.Web.UseCases.Lawyers.CreateInitial
{
    public partial class CriarUsuarioInicialCommand : IRequest<Response<UsuarioEscritorio>>
    {
        public Usuario Usuario { get; set; }
        public Escritorio Escritorio { get; set; }

        public CriarUsuarioInicialCommand()
        {
        }

        public CriarUsuarioInicialCommand(Usuario usuario, Escritorio escritorio)
        {
            Usuario = usuario;
            Escritorio = escritorio;
        }


        public CriarEscritorioCommand CriarEscritorioCommand() =>
            new CriarEscritorioCommand()
            {
                RazaoSocial = Escritorio.RazaoSocial,
                NomeFantasia = Escritorio.NomeFantasia,
                CNPJ = Escritorio.CNPJ,
                Endereco = Escritorio.Endereco
            };
    }
}
