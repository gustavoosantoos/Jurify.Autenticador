using Jurify.Autenticador.Web.Domain.Model.Entities;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Jurify.Autenticador.Web.UseCases.Services.Abstractions
{
    public interface IUsuarioEscritorioServico
    {
        Task<bool> ValidarCredenciais(string username, string password);
        Task<UsuarioEscritorio> BuscarPorUsernameAsync(string username);

        Task<UsuarioEscritorio> FindByExternalProvider(string provider, string providerUserId);
        Task<UsuarioEscritorio> AutoProvisionUser(string provider, string providerUserId, List<Claim> list);
    }
}
