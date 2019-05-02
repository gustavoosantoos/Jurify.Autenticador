using IdentityServer4.Models;
using IdentityServer4.Validation;
using Jurify.Autenticador.Application.Extensions;
using Jurify.Autenticador.Domain.Repositories;
using Jurify.Autenticador.Domain.Services.Abstractions;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Jurify.Autenticador.Application.Services.Concrete
{
    public class LawyersPasswordValidationService : IResourceOwnerPasswordValidator
    {
        private readonly IOfficeUserRepository _officeUserRepository;
        private readonly IHashService _hashService;
        private ILogger<LawyersPasswordValidationService> _logger;

        public LawyersPasswordValidationService(IOfficeUserRepository officeUserRepository, IHashService hashService, ILogger<LawyersPasswordValidationService> logger)
        {
            _officeUserRepository = officeUserRepository;
            _hashService = hashService;
            _logger = logger;
        }

        public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            try
            {
                var exists = await _officeUserRepository
                    .ExistsAsync(context.UserName, _hashService.Hash(context.Password));

                if (!exists)
                {
                    context.Result = BuildInvalidGrantValidationResult();
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
                context.Result = BuildInvalidGrantValidationResult();
            }
        }

        private GrantValidationResult BuildInvalidGrantValidationResult()
        {
            return new GrantValidationResult(
                TokenRequestErrors.InvalidGrant,
                "Login e/ou senha inválidos."
            );
        }
    }
}
