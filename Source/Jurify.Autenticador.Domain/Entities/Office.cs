using Jurify.Autenticador.Domain.Base;
using Jurify.Autenticador.Domain.ValueObjects;
using System;

namespace Jurify.Autenticador.Domain.Entities
{
    public class Office : Entity
    {
        protected Office() : base(Guid.NewGuid())
        {
        }

        public Office(Guid id, OfficeInfo info, OfficeLocation location) : base(id)
        {
            Info = info;
            Location = location;
        }

        public OfficeInfo Info { get; private set; }
        public OfficeLocation Location { get; private set; }
    }
}
