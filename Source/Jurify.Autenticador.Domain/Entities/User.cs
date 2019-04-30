using Jurify.Autenticador.Domain.Base;
using Jurify.Autenticador.Domain.ValueObjects;
using System;

namespace Jurify.Autenticador.Domain.Entities
{
    public abstract class User : Entity
    {
        public string Username { get; }
        public string Password { get; private set; }
        public ContactInfo Contact { get; private set; }
        public PersonalInfo PersonalInfo { get; private set; }

        public User(Guid id, string username, string senha) : base(id)
        {
            Username = username;
            Password = senha;
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
