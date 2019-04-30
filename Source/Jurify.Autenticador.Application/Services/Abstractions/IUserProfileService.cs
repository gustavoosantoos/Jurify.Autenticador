using System.Collections.Generic;
using System.Security.Claims;
using IdentityServer4.Services;
using Jurify.Autenticador.Domain.Entities;

namespace Jurify.Autenticador.Application.Services.Abstractions
{
    public interface IUserProfileService : IProfileService
    {
        bool ValidateCredentials(string username, string password);
        User FindByUsername(string username);
        User FindByExternalProvider(string provider, string providerUserId);
        User AutoProvisionUser(string provider, string providerUserId, List<Claim> list);
    }
}
