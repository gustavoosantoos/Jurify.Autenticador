using Jurify.Autenticador.Web.Domain.Model.Entities;
using Jurify.Autenticador.Web.UseCases.Core;
using MediatR;
using System.Collections.Generic;
using Usuario = Jurify.Autenticador.Web.UseCases.Lawyers.CreateInitial.Usuario;

namespace Jurify.Autenticador.Web.UseCases.Lawyers.ResendValidateOab
{
    public partial class ReenviarOabsValidacaoCommand : IRequest<Response<List<Oab>>>
    {

    }
}
