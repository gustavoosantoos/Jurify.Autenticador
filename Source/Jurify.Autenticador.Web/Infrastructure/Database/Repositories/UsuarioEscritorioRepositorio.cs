using Jurify.Autenticador.Web.Domain.Model.Entities;
using Jurify.Autenticador.Web.Domain.Model.Repositories;
using Jurify.Autenticador.Web.Domain.Model.Services.Abstractions;
using Jurify.Autenticador.Web.Infrastructure.Database.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Jurify.Autenticador.Web.Infrastructure.Database.Repositories
{
    public class UsuarioEscritorioRepositorio : IUsuarioEscritorioRepositorio
    {
        private readonly AutenticadorContext _context;
        private readonly IHashService _hashService;

        public UsuarioEscritorioRepositorio(AutenticadorContext context, IHashService hashService)
        {
            _context = context;
            _hashService = hashService;
        }

        public async Task<bool> ExisteAsync(Guid id)
        {
            return await _context.UsuariosEscritorio.AnyAsync(u => u.Codigo == id);
        }

        public async Task<bool> ExisteAsync(string username, string password)
        {
            var user = await BuscarPorUsernameAsync(username);
            return user != null && _hashService.Verify(user.Senha, password);
        }

        public async Task<UsuarioEscritorio> BuscarPorIdAsync(Guid id)
        {
            return await _context.UsuariosEscritorio
                .Include(u => u.Office)
                .FirstOrDefaultAsync(u => u.Codigo == id);
        }

        public async Task<UsuarioEscritorio> BuscarPorUsernameAsync(string username)
        {
            return await _context.UsuariosEscritorio
                .Include(u => u.Office)
                .FirstOrDefaultAsync(u => u.Username == username);
        }
    }
}
