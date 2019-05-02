﻿using Jurify.Autenticador.Domain.Entities;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Jurify.Autenticador.Application.Services.Abstractions
{
    public interface IClientUserService
    {
        Task<bool> ValidateCredentials(string username, string password);
        Task<ClientUser> FindByUsernameAsync(string username);

        Task<ClientUser> FindByExternalProvider(string provider, string providerUserId);
        Task<ClientUser> AutoProvisionUser(string provider, string providerUserId, List<Claim> list);
    }
}
