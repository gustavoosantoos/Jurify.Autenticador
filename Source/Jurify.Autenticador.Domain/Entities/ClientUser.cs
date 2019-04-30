using Jurify.Autenticador.Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace Jurify.Autenticador.Domain.Entities
{
    public class ClientUser : User
    {
        public ClientUser(Guid id, string username, string senha, List<Claim> claims) 
            : base(id, username, senha, claims)
        {
        }
    }
}
