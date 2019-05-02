using System;
using System.Linq;
using System.Threading.Tasks;
using Jurify.Autenticador.Domain.Entities;
using Jurify.Autenticador.Domain.Repositories;
using Jurify.Autenticador.Infra.Database.Context;
using Microsoft.EntityFrameworkCore;

namespace Jurify.Autenticador.Application.Repositories
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
                .Include(u => u.PersonalInfo)
                .Include(u => u.Contact)
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<OfficeUser> FindByUsernameAsync(string username)
        {
            return await _context.OfficeUsers
                .Include(u => u.PersonalInfo)
                .Include(u => u.Contact)
                .FirstOrDefaultAsync(u => u.Username == username);
        }
    }
}
