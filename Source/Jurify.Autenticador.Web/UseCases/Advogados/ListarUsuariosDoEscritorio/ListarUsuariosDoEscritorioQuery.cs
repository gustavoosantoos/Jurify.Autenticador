
using Jurify.Autenticador.Web.UseCases.Advogados.ListarUsuariosDoEscritorio;
using Jurify.Autenticador.Web.UseCases.Core;
using MediatR;
using System;
using System.Collections.Generic;

namespace Jurify.Autenticador.Web.UseCases.Lawyers.UserInfoQuery
{
    public class ListarUsuariosDoEscritorioQuery : IRequest<Response<List<Usuario>>>
    {
        public ListarUsuariosDoEscritorioQuery(Guid codigoEscritorio)
        {
            CodigoEscritorio = codigoEscritorio;
        }

        public Guid CodigoEscritorio { get; set; }

    }
}
