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

        public Task<OfficeUser> FindByIdAsync(Guid id)
        {
            return _context.OfficeUsers.FirstOrDefaultAsync(u => u.Id == id);
        }

        public Task<OfficeUser> FindByUsernameAsync(string username)
        {
            return _context.OfficeUsers.FirstOrDefaultAsync(u => u.Username == username);
        }
    }
}
