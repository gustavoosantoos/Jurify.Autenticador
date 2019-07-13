using System;
using System.Linq;
using System.Threading.Tasks;
using Jurify.Autenticador.Web.Domain.Model.Entities;
using Jurify.Autenticador.Web.Domain.Model.Repositories;
using Jurify.Autenticador.Web.Domain.Model.Services.Abstractions;
using Jurify.Autenticador.Web.Infrastructure.Database.Context;
using Microsoft.EntityFrameworkCore;

namespace Jurify.Autenticador.Web.Infrastructure.Database.Repositories
{
    public class OfficeUserRepository : IOfficeUserRepository
    {
        private readonly AutenticadorContext _context;
        private readonly IHashService _hashService;

        public OfficeUserRepository(AutenticadorContext context, IHashService hashService)
        {
            _context = context;
            _hashService = hashService;
        }

        public async Task<bool> ExistsAsync(Guid id)
        {
            return await _context.OfficeUsers.AnyAsync(u => u.Id == id);
        }

        public async Task<bool> ExistsAsync(string username, string password)
        {
            var user = await FindByUsernameAsync(username);
            return user != null && _hashService.Verify(user.Password, password);
        }

        public async Task<OfficeUser> FindByIdAsync(Guid id)
        {
            return await _context.OfficeUsers
                .Include(u => u.Office)
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<OfficeUser> FindByUsernameAsync(string username)
        {
            return await _context.OfficeUsers
                .Include(u => u.Office)
                .FirstOrDefaultAsync(u => u.Username == username);
        }
    }
}
