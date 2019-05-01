using Jurify.Autenticador.Domain.Entities;
using Jurify.Autenticador.Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace Jurify.Autenticador.Domain.Entities
{
    public class OfficeUser : User
    {
        public Guid OfficeId { get; private set; }

        protected OfficeUser()
        {
        }

        public OfficeUser(Guid id, Guid officeId, string username, string password, List<Claim> claims)
            : base(id, username, password, claims)
        {
            OfficeId = officeId;
        }
    }
}
