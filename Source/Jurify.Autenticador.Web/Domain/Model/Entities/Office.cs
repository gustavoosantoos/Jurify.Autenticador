using Jurify.Autenticador.Web.Domain.Model.Base;
using Jurify.Autenticador.Web.Domain.Model.ValueObjects;
using System;

namespace Jurify.Autenticador.Web.Domain.Model.Entities
{
    public class Office : Entity
    {
        protected Office() : base(Guid.NewGuid())
        {
        }

        public Office(OfficeInfo info, OfficeLocation location) : base(Guid.NewGuid())
        {
            Info = info;
            Location = location;
        }

        public OfficeInfo Info { get; private set; }
        public OfficeLocation Location { get; private set; }
    }
}
