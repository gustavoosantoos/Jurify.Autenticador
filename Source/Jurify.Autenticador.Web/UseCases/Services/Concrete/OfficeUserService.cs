using Jurify.Autenticador.Web.Domain.Model.Entities;
using Jurify.Autenticador.Web.Domain.Model.Repositories;
using Jurify.Autenticador.Web.Domain.Model.Services.Abstractions;
using Jurify.Autenticador.Web.UseCases.Services.Abstractions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Jurify.Autenticador.Web.UseCases.Services.Concrete
{
    public class OfficeUserService : IOfficeUserService
    {
        private readonly IUsuarioEscritorioRepositorio _officeUserRepository;
        private readonly IHashService _hashService;
        private readonly ILogger<OfficeUserService> _logger;

        public OfficeUserService(
            IUsuarioEscritorioRepositorio officeUserRepository,
            IHashService hashService,
            ILogger<OfficeUserService> logger)
        {
            _officeUserRepository = officeUserRepository;
            _hashService = hashService;
            _logger = logger;
        }

        public Task<UsuarioEscritorio> AutoProvisionUser(string provider, string providerUserId, List<Claim> list)
        {
            throw new NotImplementedException();
        }

        public Task<UsuarioEscritorio> FindByExternalProvider(string provider, string providerUserId)
        {
            throw new NotImplementedException();
        }

        public async Task<UsuarioEscritorio> FindByUsernameAsync(string username)
        {
            return await _officeUserRepository.BuscarPorUsernameAsync(username);
        }

        public async Task<bool> ValidateCredentials(string username, string password)
        {
            _logger.LogInformation("Trying to validate credentials for user: {User}", username);

            if (string.IsNullOrWhiteSpace(username))
                return false;

            var user = await _officeUserRepository.BuscarPorUsernameAsync(username);

            if (user == null)
                return false;

            return _hashService.Verify(user.Senha, password);
        }
    }
}
