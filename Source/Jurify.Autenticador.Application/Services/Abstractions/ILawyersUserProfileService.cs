using IdentityServer4.Services;
using IdentityServer4.Validation;
using Jurify.Autenticador.Domain.Entities;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Jurify.Autenticador.Application.Services.Abstractions
{
    public interface ILaywersUserProfileService : IProfileService, IResourceOwnerPasswordValidator
    {
        Task<bool> ValidateCredentials(string username, string password);
        Task<OfficeUser> FindByUsernameAsync(string username);
        Task<OfficeUser> FindByExternalProvider(string provider, string providerUserId);
        Task<OfficeUser> AutoProvisionUser(string provider, string providerUserId, List<Claim> list);
    }
}
