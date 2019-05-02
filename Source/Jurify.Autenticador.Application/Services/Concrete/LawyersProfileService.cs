using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Services;
using Jurify.Autenticador.Application.Extensions;
using Jurify.Autenticador.Domain.Repositories;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Jurify.Autenticador.Application.Services.Concrete
{
    public class LawyersProfileService : IProfileService
    {
        private readonly IOfficeUserRepository _officeUserRepository;

        public LawyersProfileService(IOfficeUserRepository officeUserRepository)
        {
            _officeUserRepository = officeUserRepository;
        }

        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
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

        public async Task IsActiveAsync(IsActiveContext context)
        {
            var userId = context.Subject.Claims.First(c => c.Type == JwtClaimTypes.Subject);

            if (Guid.TryParse(userId.Value, out var guidId))
            {
                context.IsActive = await _officeUserRepository.ExistsAsync(guidId);
            }
        }
    }
}
