using Jurify.Autenticador.Web.Domain.Model.Entities;
using Jurify.Autenticador.Web.UseCases.Core;
using MediatR;
using System;

namespace Jurify.Autenticador.Web.UseCases.Lawyers.UserInfoQuery
{
    public class UserInfoQuery : IRequest<Response<UsuarioEscritorio>>
    {
        public UserInfoQuery(Guid officeId, Guid userId)
        {
            OfficeId = officeId;
            UserId = userId;
        }

        public Guid OfficeId { get; set; }
        public Guid UserId { get; set; }

    }
}
