using IdentityServer4.Models;
using Jurify.Autenticador.Application.Services.Abstractions;
using Jurify.Autenticador.Domain.Entities;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Jurify.Autenticador.Application.Services.Concrete
{
    public class UserProfileService : IUserProfileService
    {
        public User AutoProvisionUser(string provider, string providerUserId, List<Claim> list)
        {
            throw new System.NotImplementedException();
        }

        public User FindByExternalProvider(string provider, string providerUserId)
        {
            throw new System.NotImplementedException();
        }

        public User FindByUsername(string username)
        {
            throw new System.NotImplementedException();
        }

        public Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            throw new System.NotImplementedException();
        }

        public Task IsActiveAsync(IsActiveContext context)
        {
            throw new System.NotImplementedException();
        }

        public bool ValidateCredentials(string username, string password)
        {
            throw new System.NotImplementedException();
        }
    }
}
