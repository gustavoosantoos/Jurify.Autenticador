using Jurify.Autenticador.Web.Domain.Model.Entities;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Jurify.Autenticador.Web.UseCases.Services.Abstractions
{
    public interface IOfficeUserService
    {
        Task<bool> ValidateCredentials(string username, string password);
        Task<OfficeUser> FindByUsernameAsync(string username);

        Task<OfficeUser> FindByExternalProvider(string provider, string providerUserId);
        Task<OfficeUser> AutoProvisionUser(string provider, string providerUserId, List<Claim> list);
    }
}
