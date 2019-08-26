using Jurify.Autenticador.Web.Domain.Model.Entities;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Jurify.Autenticador.Web.UseCases.Services.Abstractions
{
    public interface IClientUserService
    {
        Task<bool> ValidateCredentials(string username, string password);
        Task<UsuarioCliente> FindByUsernameAsync(string username);

        Task<UsuarioCliente> FindByExternalProvider(string provider, string providerUserId);
        Task<UsuarioCliente> AutoProvisionUser(string provider, string providerUserId, List<Claim> list);
    }
}
