using Jurify.Autenticador.Web.Infrastructure.Database.Context;
using Jurify.Autenticador.Web.UseCases.Core;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Jurify.Autenticador.Web.UseCases.Offices.Create
{
    public class CriarEscritorioCommandHandler : IRequestHandler<CriarEscritorioCommand, Response<Guid>>
    {
        private readonly AutenticadorContext _context;

        public CriarEscritorioCommandHandler(AutenticadorContext context)
        {
            _context = context;
        }

        public async Task<Response<Guid>> Handle(CriarEscritorioCommand request, CancellationToken cancellationToken)
        {
            var existsOfficeWithSameName = await _context.Escritorios
                .AnyAsync(o => o.Informacoes.RazaoSocial == request.RazaoSocial || 
                               o.Informacoes.CNPJ == request.CNPJ);

            if (existsOfficeWithSameName)
            {
                return Response<Guid>.WithErrors("Já existe um escritório com a mesma razão social ou CNPJ");
            }

            var office = request.AsOffice();

            await _context.Escritorios.AddAsync(office);
            await _context.SaveChangesAsync();
            
            return Response<Guid>.WithResult(office.Codigo);
        }
    }
}
