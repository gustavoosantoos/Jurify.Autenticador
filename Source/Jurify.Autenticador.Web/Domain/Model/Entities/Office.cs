using Jurify.Autenticador.Web.Domain.Model.Base;
using Jurify.Autenticador.Web.Domain.Model.ValueObjects;
using System;
using System.Collections.Generic;

namespace Jurify.Autenticador.Web.Domain.Model.Entities
{
    public class Office : Entity
    {
        protected Office() : base(Guid.NewGuid())
        {
        }

        public Office(OfficeInfo info) : base(Guid.NewGuid())
        {
            Info = info;
        }

        public OfficeInfo Info { get; private set; }
        public List<OfficeUser> Users { get; private set; }
    }
}
