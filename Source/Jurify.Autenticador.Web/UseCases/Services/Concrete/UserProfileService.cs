using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Services;
using Jurify.Autenticador.Web.Domain.Model.Entities;
using Jurify.Autenticador.Web.Domain.Model.Repositories;
using Jurify.Autenticador.Web.Infrastructure.Configuration.IdentityServer;
using Jurify.Autenticador.Web.Infrastructure.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Jurify.Autenticador.Web.UseCases.Services.Concrete
{
    public class UserProfileService : IProfileService
    {
        private readonly IUsuarioEscritorioRepositorio _officeUserRepository;
        private readonly IEscritorioRepositorio _officeRepository;

        public UserProfileService(IEscritorioRepositorio officeRepository, IUsuarioEscritorioRepositorio officeUserRepository)
        {
            _officeUserRepository = officeUserRepository;
            _officeRepository = officeRepository;
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
                var user = await _officeUserRepository.BuscarPorIdAsync(guidId);

                var userClaims = GetUserInfoClaims(user)
                                .Concat(user.Permissoes.AsSecurityClaims())
                                .ToList();

                context.IssuedClaims = userClaims;
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
                context.IsActive = await _officeUserRepository.ExisteAsync(guidId);
            }
        }

        private Task<bool> ClientUserIsActiveAsync(IsActiveContext context)
        {
            throw new NotImplementedException("Client user activity not implemented");
        }

        private List<Claim> GetUserInfoClaims(UsuarioEscritorio user)
        {
            return new List<Claim>
            {
                new Claim("user_id", user.Codigo.ToString()),
                new Claim("user_first_name", user.InformacoesPessoais.PrimeiroNome),
                new Claim("user_last_name", user.InformacoesPessoais.UltimoNome),
                new Claim("office_id", user.Office.Codigo.ToString()),
                new Claim("office_name", user.Office.Informacoes.NomeFantasia)
            };
        }
    }
}
