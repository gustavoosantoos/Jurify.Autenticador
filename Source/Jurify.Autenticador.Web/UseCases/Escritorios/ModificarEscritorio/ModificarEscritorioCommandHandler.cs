using Jurify.Autenticador.Web.Domain.Model.Entities;
using Jurify.Autenticador.Web.Domain.Model.Services.Abstractions;
using Jurify.Autenticador.Web.Domain.Model.ValueObjects;
using Jurify.Autenticador.Web.Infrastructure.Database.Context;
using Jurify.Autenticador.Web.UseCases.Core;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Jurify.Autenticador.Web.UseCases.Offices.Modify
{
    public class ModificarEscritorioCommandHandler : IRequestHandler<ModificarEscritorioCommand, Response<Escritorio>>
    {
        private readonly AutenticadorContext _context;
        private readonly IMediator _mediator;
        private readonly IHashService _hashService;
        private readonly IGeocodingService _geocodingService;


        public ModificarEscritorioCommandHandler(
            AutenticadorContext context,
            IMediator mediator,
            IHashService hashService,
            IGeocodingService geocodingService)
        {
            _context = context;
            _mediator = mediator;
            _hashService = hashService;
            _geocodingService = geocodingService;
        }

        public async Task<Response<Escritorio>> Handle(ModificarEscritorioCommand request, CancellationToken cancellationToken)
        {
            var result = Response<Escritorio>.WithResult(null);
            var escritorio = await _context.Escritorios
                .FirstOrDefaultAsync(u => u.Informacoes.CNPJ == request.CNPJ) ;
            var enderecoCompleto = $"{request.Endereco.Rua}, {request.Endereco.Numero} - {request.Endereco.Cidade} - {request.Endereco.Estado}";
            var (lat, lon) = await _geocodingService.ObterCoordenadas(enderecoCompleto);

            if (escritorio == null)
            {
                result.AddError("Usuario não encontrado para modificar");
                return result;
            }

            escritorio.AtualizarInformacoesEscritorio(new InformacoesDoEscritorio(request.NomeFantasia, request.RazaoSocial, request.CNPJ));
            escritorio.AtualizarEndereco(new Domain.Model.Entities.Endereco(
                    request.Endereco.CEP,
                    request.Endereco.Rua,
                    request.Endereco.Numero,
                    request.Endereco.Complemento,
                    request.Endereco.Bairro,
                    request.Endereco.Cidade,
                    request.Endereco.Estado,
                    lat,
                    lon
                ));

            _context.Escritorios.Update(escritorio);
            await _context.SaveChangesAsync();

            return Response<Escritorio>.WithResult(escritorio);
        }


    }
}
