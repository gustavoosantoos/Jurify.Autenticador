using Jurify.Autenticador.Web.Domain.Model.Base;
using Jurify.Autenticador.Web.Domain.Model.ValueObjects;
using System;
using System.Collections.Generic;

namespace Jurify.Autenticador.Web.Domain.Model.Entities
{
    public abstract class User : Entity
    {
        public string Username { get; private set; }
        public string Password { get; private set; }
        public PersonalInfo PersonalInfo { get; private set; }
        public List<Claim> Claims { get; private set; }

        protected User() : base(Guid.NewGuid())
        {
        }

        public User(
            Guid id,
            string username,
            string senha,
            PersonalInfo personalInfo,
            List<Claim> claims) : base(id)
        {
            Username = username;
            Password = senha;
            PersonalInfo = personalInfo;
            Claims = claims;
        }

        public void UpdatePassword(string newPassword)
        {
            Password = newPassword;
        }

        public void UpdatePersonalInfo(PersonalInfo newInformations)
        {
            PersonalInfo = newInformations;
        }
    }
}
