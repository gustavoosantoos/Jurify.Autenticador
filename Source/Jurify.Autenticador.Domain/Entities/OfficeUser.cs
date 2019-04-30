using Jurify.Autenticador.Domain.Entities;
using Jurify.Autenticador.Domain.ValueObjects;
using System;

namespace Jurify.Autenticador.Domain.Model
{
    public class OfficeUser : User
    {
        public OfficeIdentifier OfficeId { get; }

        public OfficeUser(Guid id, OfficeIdentifier officeId, string username, string password) 
            : base(id, username, password)
        {
            OfficeId = officeId;
        }
    }
}
