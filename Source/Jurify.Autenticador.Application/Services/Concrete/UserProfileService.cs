using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Services;
using Jurify.Autenticador.Application.Configuration.IdentityServer;
using Jurify.Autenticador.Application.Extensions;
using Jurify.Autenticador.Domain.Repositories;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Jurify.Autenticador.Application.Services.Concrete
{
    public class UserProfileService : IProfileService
    {
        private readonly IOfficeUserRepository _officeUserRepository;

        public UserProfileService(IOfficeUserRepository officeUserRepository)
        {
            _officeUserRepository = officeUserRepository;
        }

        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            switch (context.Client.ClientName)
            {
                case IdentityServerConfiguration.Clients.JurifyWebLawyers:
                    await GetOfficeUserProfileDataAsync(context);
                    break;
                case IdentityServerConfiguration.Clients.JurifyWebClient:
                    await GetClientUserProfileDataAsync(context);
                    break;
                default:
                    throw new NotImplementedException("Client not identified for querying profile data");
            }
        }

        public async Task IsActiveAsync(IsActiveContext context)
        {
            switch (context.Client.ClientName)
            {
                case IdentityServerConfiguration.Clients.JurifyWebLawyers:
                    await OfficeUserIsActiveAsync(context);
                    break;
                case IdentityServerConfiguration.Clients.JurifyWebClient:
                    await ClientUserIsActiveAsync(context);
                    break;
                default:
                    throw new NotImplementedException("Client not identified for querying profile data");
            }
        }

        private async Task GetOfficeUserProfileDataAsync(ProfileDataRequestContext context)
        {
            var userId = context.Subject.Claims.First(c => c.Type == JwtClaimTypes.Subject);

            if (Guid.TryParse(userId.Value, out var guidId))
            {
                var user = await _officeUserRepository.FindByIdAsync(guidId);
                context.IssuedClaims = user
                    .Claims
                    .AsSecurityClaims()
                    .Where(c => context.RequestedClaimTypes.Contains(c.Type))
                    .ToList();
            }
        }

        private Task GetClientUserProfileDataAsync(ProfileDataRequestContext context)
        {
            throw new NotImplementedException("Client user profile data not implemented");
        }

        private async Task OfficeUserIsActiveAsync(IsActiveContext context)
        {
            var userId = context.Subject.Claims.First(c => c.Type == JwtClaimTypes.Subject);

            if (Guid.TryParse(userId.Value, out var guidId))
            {
                context.IsActive = await _officeUserRepository.ExistsAsync(guidId);
            }
        }

        private Task<bool> ClientUserIsActiveAsync(IsActiveContext context)
        {
            throw new NotImplementedException("Client user activity not implemented");
        }
    }
}
