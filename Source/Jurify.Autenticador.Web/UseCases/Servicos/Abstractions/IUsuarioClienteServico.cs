using Jurify.Autenticador.Web.Domain.Model.Entities;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Jurify.Autenticador.Web.UseCases.Services.Abstractions
{
    public interface IUsuarioClienteServico
    {
        Task<bool> ValidarCredenciais(string username, string password);
        Task<UsuarioCliente> BuscarPorUsernameAsync(string username);

        Task<UsuarioCliente> FindByExternalProvider(string provider, string providerUserId);
        Task<UsuarioCliente> AutoProvisionUser(string provider, string providerUserId, List<Claim> list);
    }
}
