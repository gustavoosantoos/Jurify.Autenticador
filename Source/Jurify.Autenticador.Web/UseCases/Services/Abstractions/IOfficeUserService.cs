using Jurify.Autenticador.Web.Domain.Model.Entities;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Jurify.Autenticador.Web.UseCases.Services.Abstractions
{
    public interface IOfficeUserService
    {
        Task<bool> ValidateCredentials(string username, string password);
        Task<UsuarioEscritorio> FindByUsernameAsync(string username);

        Task<UsuarioEscritorio> FindByExternalProvider(string provider, string providerUserId);
        Task<UsuarioEscritorio> AutoProvisionUser(string provider, string providerUserId, List<Claim> list);
    }
}
