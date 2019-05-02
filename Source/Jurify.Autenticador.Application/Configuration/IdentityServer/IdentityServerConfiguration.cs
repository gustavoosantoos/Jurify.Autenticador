namespace Jurify.Autenticador.Application.Configuration.IdentityServer
{
    public class IdentityServerConfiguration
    {
        public class Clients
        {
            public const string JurifyWebClient = "jurify.web.clients";
            public const string JurifyWebLawyers = "jurify.web.lawyers";
        }

        public class ApiResources
        {
            public const string JurifyApi = "jurify.api";
            public const string JurifyChat = "jurify.chat";
        }
    }
}
