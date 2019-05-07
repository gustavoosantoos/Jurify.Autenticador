using System;
using System.Linq;
using System.Threading.Tasks;
using Jurify.Autenticador.Web.Domain.Model.Entities;
using Jurify.Autenticador.Web.Domain.Model.Repositories;
using Jurify.Autenticador.Web.Infrastructure.Database.Context;
using Microsoft.EntityFrameworkCore;

namespace Jurify.Autenticador.Web.Infrastructure.Database.Repositories
{
    public class OfficeUserRepository : IOfficeUserRepository
    {
        private readonly AutenticadorContext _context;

        public OfficeUserRepository(AutenticadorContext context)
        {
            _context = context;
        }

        public async Task<bool> ExistsAsync(Guid id)
        {
            return await _context.OfficeUsers.AnyAsync(u => u.Id == id);
        }

        public async Task<bool> ExistsAsync(string username, string password)
        {
            return await _context.OfficeUsers.AnyAsync(u => u.Username == username && u.Password == password);
        }

        public async Task<OfficeUser> FindByIdAsync(Guid id)
        {
            return await _context.OfficeUsers
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<OfficeUser> FindByUsernameAsync(string username)
        {
            return await _context.OfficeUsers
                .FirstOrDefaultAsync(u => u.Username == username);
        }
    }
}
