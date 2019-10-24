using Jurify.Autenticador.Web.Domain.Model.Entities;
using Jurify.Autenticador.Web.UseCases.Core;
using MediatR;
using System;
using Usuario = Jurify.Autenticador.Web.UseCases.Lawyers.CreateInitial.Usuario;

namespace Jurify.Autenticador.Web.UseCases.Lawyers.ValidateOab
{
    public partial class ValidarOabCommand : IRequest<Response<OabValidada>>
    {
        public Guid CodigoAdvogado { get; set; }
        public string NumeroOab { get; set; }
        public string Uf { get; set; }
        public string CaminhoImagem { get; set; }
        public bool? Ativo { get; set; }
        public bool? Existe { get; set; }

        public ValidarOabCommand()
        {
        }




    }
}
