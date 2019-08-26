using Jurify.Autenticador.Web.Domain.Model.Entities;
using Jurify.Autenticador.Web.UseCases.Core;
using MediatR;
using System;

namespace Jurify.Autenticador.Web.UseCases.Lawyers.UserInfoQuery
{
    public class DadosUsuarioQuery : IRequest<Response<UsuarioEscritorio>>
    {
        public DadosUsuarioQuery(Guid codigoEscritorio, Guid codigoUsuario)
        {
            CodigoEscritorio = codigoEscritorio;
            CodigoUsuario = codigoUsuario;
        }

        public Guid CodigoEscritorio { get; set; }
        public Guid CodigoUsuario { get; set; }

    }
}
