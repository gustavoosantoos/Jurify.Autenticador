using Jurify.Autenticador.Web.Domain.Model.Entities;
using Jurify.Autenticador.Web.UseCases.Core;
using MediatR;
using System;

namespace Jurify.Autenticador.Web.UseCases.Lawyers.UserInfoQuery
{
    public class ListarUsuariosDoEscritorioQuery : IRequest<Response<UsuarioEscritorio>>
    {
        public ListarUsuariosDoEscritorioQuery(Guid codigoEscritorio)
        {
            CodigoEscritorio = codigoEscritorio;
        }

        public Guid CodigoEscritorio { get; set; }

    }
}
