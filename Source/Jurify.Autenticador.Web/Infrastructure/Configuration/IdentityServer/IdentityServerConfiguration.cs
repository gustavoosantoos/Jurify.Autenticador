using IdentityServer4.Models;
using System.Collections.Generic;

namespace Jurify.Autenticador.Web.Infrastructure.Configuration.IdentityServer
{
    public class IdentityServerConfiguration
    {
        public class Resources
        {
            public static List<IdentityResource> GetIdentityResources()
            {
                return new List<IdentityResource>
                {
                    new IdentityResources.OpenId(),
                    new IdentityResources.Profile()
                };
            }
        }

        public class ApiResources
        {
            public const string JurifyApiClients = "jurify.api.clients";
            public const string JurifyApiLawyers = "jurify.api.lawyers";
            public const string JurifyApiChat = "jurify.api.chat";

            public static List<ApiResource> GetApiResources()
            {
                return new List<ApiResource>
                {
                    new ApiResource(JurifyApiClients),
                    new ApiResource(JurifyApiLawyers),
                    new ApiResource(JurifyApiChat)
                };
            }
        }

        public class Clients
        {
            public const string JurifyWebClient = "jurify.web.clients";
            public const string JurifyWebLawyers = "jurify.web.lawyers";

            public static List<Client> GetClients()
            {
                return new List<Client>
                {
                    new Client
                    {
                        ClientId = JurifyWebLawyers,
                        ClientName = JurifyWebLawyers,
                        ClientSecrets = new [] { new Secret(JurifyWebLawyers.Sha256()) },
                        AccessTokenType = AccessTokenType.Jwt,
                        AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                        AllowedScopes = new [] { "openid", "profile", ApiResources.JurifyApiLawyers },
                        RequireConsent = false,
                        RefreshTokenExpiration = TokenExpiration.Sliding,
                        AllowedCorsOrigins = new [] 
                        {
                            "http://localhost:4200"
                        }
                    },
                    new Client
                    {
                        ClientId = JurifyWebClient,
                        ClientName = JurifyWebClient,
                        ClientSecrets = new [] { new Secret(JurifyWebClient.Sha256()) },
                        AccessTokenType = AccessTokenType.Jwt,
                        AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                        AllowedScopes = new [] { "openid", "profile", ApiResources.JurifyApiClients },
                        RequireConsent = false,
                        RefreshTokenExpiration = TokenExpiration.Sliding
                    }
                };
            }
        }
    }
}
