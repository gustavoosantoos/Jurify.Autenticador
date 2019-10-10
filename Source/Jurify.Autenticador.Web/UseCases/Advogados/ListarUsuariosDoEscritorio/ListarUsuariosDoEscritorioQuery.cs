
using Jurify.Autenticador.Web.UseCases.Advogados.ListarUsuariosDoEscritorio;
using Jurify.Autenticador.Web.UseCases.Core;
using MediatR;
using System;
using System.Collections.Generic;

namespace Jurify.Autenticador.Web.UseCases.Lawyers.UserInfoQuery
{
    public class ListarUsuariosDoEscritorioQuery : IRequest<Response<List<Usuario>>>
    {
        public ListarUsuariosDoEscritorioQuery(string cnpj)
        {
            Cnpj = cnpj;
        }

        public string Cnpj { get; set; }

    }
}
