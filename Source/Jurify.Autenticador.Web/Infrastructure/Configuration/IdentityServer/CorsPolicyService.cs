using System.Threading.Tasks;
using IdentityServer4.Services;

namespace Jurify.Autenticador.Web.Infrastructure.Configuration.IdentityServer
{
    public class CorsPolicyService : ICorsPolicyService
    {
        public Task<bool> IsOriginAllowedAsync(string origin)
        {
            return Task.FromResult(true);
        }
    }
}
