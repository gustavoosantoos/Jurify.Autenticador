using Jurify.Autenticador.Web.Domain.Model.Entities;
using Jurify.Autenticador.Web.Domain.Model.Repositories;
using Jurify.Autenticador.Web.Infrastructure.Database.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Jurify.Autenticador.Web.Infrastructure.Database.Repositories
{
    public class EscritorioRepositorio : IEscritorioRepositorio
    {
        private readonly AutenticadorContext _context;

        public EscritorioRepositorio(AutenticadorContext context)
        {
            _context = context;
        }

        public async Task<Escritorio> BuscarPorIdAsync(Guid officeId)
        {
            return await _context.Escritorios.FirstOrDefaultAsync(o => o.Codigo == officeId);
        }

        public async Task<Escritorio> BuscarPorNomeAsync(string officeName)
        {
            return await _context.Escritorios.FirstOrDefaultAsync(o => o.Informacoes.NomeFantasia == officeName);
        }
    }
}
