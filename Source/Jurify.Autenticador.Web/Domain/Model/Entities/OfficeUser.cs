using Jurify.Autenticador.Web.Domain.Model.ValueObjects;
using System;
using System.Collections.Generic;

namespace Jurify.Autenticador.Web.Domain.Model.Entities
{
    public class OfficeUser : User
    {
        public Guid OfficeId { get; private set; }
        public Office Office { get; private set; }

        protected OfficeUser()
        {
        }

        public OfficeUser(Guid officeId,
                          string username,
                          string senha,
                          PersonalInfo personalInfo,
                          List<Claim> claims) : base(Guid.NewGuid(), username, senha, personalInfo, claims)
        {
            OfficeId = officeId;
        }
    }
}
