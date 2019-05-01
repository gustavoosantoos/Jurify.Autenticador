using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Validation;
using Jurify.Autenticador.Application.Extensions;
using Jurify.Autenticador.Application.Services.Abstractions;
using Jurify.Autenticador.Domain.Entities;
using Jurify.Autenticador.Domain.Repositories;
using Jurify.Autenticador.Domain.Services.Abstractions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Jurify.Autenticador.Application.Services.Concrete
{
    public class LawyersUserProfileService : ILaywersUserProfileService
    {
        private readonly IOfficeUserRepository _officeUserRepository;
        private readonly IHashService _hashService;
        private readonly ILogger<LawyersUserProfileService> _logger;

        public LawyersUserProfileService(
            IOfficeUserRepository officeUserRepository,
            IHashService hashService,
            ILogger<LawyersUserProfileService> logger)
        {
            _officeUserRepository = officeUserRepository;
            _hashService = hashService;
            _logger = logger;
        }

        public Task<OfficeUser> AutoProvisionUser(string provider, string providerUserId, List<Claim> list)
        {
            throw new NotImplementedException();
        }

        public Task<OfficeUser> FindByExternalProvider(string provider, string providerUserId)
        {
            throw new NotImplementedException();
        }

        public async Task<OfficeUser> FindByUsernameAsync(string username)
        {
            return await _officeUserRepository.FindByUsernameAsync(username);
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

        public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            var loginError = new GrantValidationResult(
                TokenRequestErrors.InvalidGrant,
                "Login e/ou senha inválidos."
            );

            try
            {
                var exists = await _officeUserRepository
                    .ExistsAsync(context.UserName, _hashService.Hash(context.Password));

                if (!exists)
                {
                    context.Result = loginError;
                    return;
                }

                var user = await _officeUserRepository.FindByUsernameAsync(context.UserName);

                context.Result = new GrantValidationResult(
                    subject: user.Id.ToString(),
                    authenticationMethod: "custom",
                    claims: user.Claims.AsSecurityClaims()
                );
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                context.Result = loginError;
            }
        }

        public async Task<bool> ValidateCredentials(string username, string password)
        {
            _logger.LogInformation("Trying to validate credentials for user: {User}", username);

            if (string.IsNullOrWhiteSpace(username))
                return false;

            var user = await _officeUserRepository.FindByUsernameAsync(username);

            if (user == null)
                return false;

            return _hashService.Verify(user.Password, password);
        }
    }
}
