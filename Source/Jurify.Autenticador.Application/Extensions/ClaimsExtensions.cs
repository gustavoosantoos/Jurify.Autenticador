using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Jurify.Autenticador.Application.Extensions
{
    public static class ClaimsExtensions
    {
        public static List<Claim> AsSecurityClaims(this List<Domain.ValueObjects.Claim> claims)
        {
            return claims.Select(c => new Claim(c.Name, c.Value)).ToList();
        }
    }
}
