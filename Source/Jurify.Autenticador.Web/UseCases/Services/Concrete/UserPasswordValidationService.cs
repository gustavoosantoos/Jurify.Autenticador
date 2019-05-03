using IdentityServer4.Models;
using IdentityServer4.Validation;
using Jurify.Autenticador.Web.Domain.Model.Repositories;
using Jurify.Autenticador.Web.Domain.Model.Services.Abstractions;
using Jurify.Autenticador.Web.Infrastructure.Configuration.IdentityServer;
using Jurify.Autenticador.Web.Infrastructure.Extensions;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Jurify.Autenticador.Web.UseCases.Services.Concrete
{
    public class UserPasswordValidationService : IResourceOwnerPasswordValidator
    {
        private readonly IOfficeUserRepository _officeUserRepository;
        private readonly IHashService _hashService;
        private readonly ILogger<UserPasswordValidationService> _logger;

        public UserPasswordValidationService(
            IOfficeUserRepository officeUserRepository,
            IHashService hashService,
            ILogger<UserPasswordValidationService> logger)
        {
            _officeUserRepository = officeUserRepository;
            _hashService = hashService;
            _logger = logger;
        }

        public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            switch (context.Request.Client.ClientName)
            {
                case IdentityServerConfiguration.Clients.JurifyWebLawyers:
                    await ValidateOfficeUserAsync(context);
                    break;
                case IdentityServerConfiguration.Clients.JurifyWebClient:
                    await ValidateClientUserAsync(context);
                    break;
                default:
                    throw new NotImplementedException("Client not identified for querying profile data");
            }
        }

        private async Task ValidateOfficeUserAsync(ResourceOwnerPasswordValidationContext context)
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

        private async Task ValidateClientUserAsync(ResourceOwnerPasswordValidationContext context)
        {
            await Task.Delay(0);
            throw new NotImplementedException("Validation of client users not implemented");
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
