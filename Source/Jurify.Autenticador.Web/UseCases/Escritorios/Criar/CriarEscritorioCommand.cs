using Jurify.Autenticador.Web.Domain.Model.Services.Abstractions;
using Jurify.Autenticador.Web.Domain.Model.ValueObjects;
using Jurify.Autenticador.Web.UseCases.Core;
using MediatR;
using System;
using System.Threading.Tasks;
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

        public async Task<Escritorio> AsOffice(IGeocodingService geocodingService)
        {
            var enderecoCompleto = $"{Endereco.Rua}, {Endereco.Numero} - {Endereco.Cidade} - {Endereco.Estado}";
            var (lat, lon) = await geocodingService.ObterCoordenadas(enderecoCompleto);

            return new Escritorio(
                new InformacoesDoEscritorio(NomeFantasia, RazaoSocial, CNPJ),
                new Domain.Model.Entities.Endereco(
                    Endereco.CEP,
                    Endereco.Rua,
                    Endereco.Numero,
                    Endereco.Complemento,
                    Endereco.Bairro,
                    Endereco.Cidade,
                    Endereco.Estado,
                    lat,
                    lon
                )
            );
        }
    }
}
