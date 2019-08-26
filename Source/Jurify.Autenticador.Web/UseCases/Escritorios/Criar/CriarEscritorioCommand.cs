using Jurify.Autenticador.Web.Domain.Model.ValueObjects;
using Jurify.Autenticador.Web.UseCases.Core;
using MediatR;
using System;
using Endereco = Jurify.Autenticador.Web.UseCases.Lawyers.CreateInitial.Endereco;
using Escritorio = Jurify.Autenticador.Web.Domain.Model.Entities.Escritorio;

namespace Jurify.Autenticador.Web.UseCases.Offices.Create
{
    public class CriarEscritorioCommand : IRequest<Response<Guid>>
    {
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string CNPJ { get; set; }
        public Endereco Endereco { get; set; }

        public Escritorio AsOffice()
        {
            return new Escritorio(
                new InformacoesDoEscritorio(NomeFantasia, RazaoSocial, CNPJ)
            );
        }
    }
}
