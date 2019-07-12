using System;
using System.Threading.Tasks;
using Jurify.Autenticador.Web.Domain.Model.Entities;
using Jurify.Autenticador.Web.Domain.Model.Repositories;
using Jurify.Autenticador.Web.Infrastructure.Database.Context;
using Microsoft.EntityFrameworkCore;

namespace Jurify.Autenticador.Web.Infrastructure.Database.Repositories
{
    public class OfficeRepository : IOfficeRepository
    {
        private readonly AutenticadorContext _context;

        public OfficeRepository(AutenticadorContext context)
        {
            _context = context;
        }

        public async Task<Office> FindByIdAsync(Guid officeId)
        {
            return await _context.Offices.FirstOrDefaultAsync(o => o.Id == officeId);
        }

        public async Task<Office> FindByNameAsync(string officeName)
        {
            return await _context.Offices.FirstOrDefaultAsync(o => o.Info.Name == officeName);
        }
    }
}
