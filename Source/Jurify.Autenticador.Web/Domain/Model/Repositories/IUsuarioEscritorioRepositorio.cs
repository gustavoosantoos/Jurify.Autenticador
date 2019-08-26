using Jurify.Autenticador.Web.Domain.Model.Entities;
using System;
using System.Threading.Tasks;

namespace Jurify.Autenticador.Web.Domain.Model.Repositories
{
    public interface IUsuarioEscritorioRepositorio
    {
        Task<UsuarioEscritorio> BuscarPorIdAsync(Guid id);
        Task<UsuarioEscritorio> BuscarPorUsernameAsync(string username);
        Task<bool> ExisteAsync(Guid id);
        Task<bool> ExisteAsync(string username, string password);
    }
}
