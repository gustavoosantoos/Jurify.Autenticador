using Jurify.Autenticador.Domain.Entities;
using Jurify.Autenticador.Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace Jurify.Autenticador.Domain.Model
{
    public class OfficeUser : User
    {
        public OfficeIdentifier OfficeId { get; }

        public OfficeUser(Guid id, OfficeIdentifier officeId, string username, string password, List<Claim> claims) 
            : base(id, username, password, claims)
        {
            OfficeId = officeId;
        }
    }
}
