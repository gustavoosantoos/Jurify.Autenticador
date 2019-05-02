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
    public class LawyersUserService : ILaywersUserService
    {
        private readonly IOfficeUserRepository _officeUserRepository;
        private readonly IHashService _hashService;
        private readonly ILogger<LawyersUserService> _logger;

        public LawyersUserService(
            IOfficeUserRepository officeUserRepository,
            IHashService hashService,
            ILogger<LawyersUserService> logger)
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
