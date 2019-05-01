using Jurify.Autenticador.Domain.Base;
using Jurify.Autenticador.Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace Jurify.Autenticador.Domain.Entities
{
    public abstract class User : Entity
    {
        public string Username { get; private set; }
        public string Password { get; private set; }
        public ContactInfo Contact { get; private set; }
        public PersonalInfo PersonalInfo { get; private set; }
        public List<Claim> Claims { get; private set; }

        protected User() : base(Guid.NewGuid())
        {
        }

        public User(
            Guid id,
            string username, 
            string senha, 
            ContactInfo contactInfo, 
            PersonalInfo personalInfo, 
            List<Claim> claims) : base(id)
        {
            Username = username;
            Password = senha;
            PersonalInfo = personalInfo;
            Contact = contactInfo;
            Claims = claims;
        }

        public void UpdatePassword(string newPassword)
        {
            Password = newPassword;
        }

        public void UpdateEmail(ContactEmail newEmail)
        {
            Contact = new ContactInfo(newEmail, Contact.Phone);
        }

        public void UpdatePhoneNumber(PhoneNumber newPhone)
        {
            Contact = new ContactInfo(Contact.Email, newPhone);
        }

        public void UpdatePersonalInfo(PersonalInfo newInformations)
        {
            PersonalInfo = newInformations;
        }
    }
}
