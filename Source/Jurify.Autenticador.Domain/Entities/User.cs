﻿using Jurify.Autenticador.Domain.Base;
using Jurify.Autenticador.Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace Jurify.Autenticador.Domain.Entities
{
    public abstract class User : Entity
    {
        public string Username { get; }
        public string Password { get; private set; }
        public ContactInfo Contact { get; private set; }
        public PersonalInfo PersonalInfo { get; private set; }
        public List<Claim> Claims { get; private set; }

        public User(Guid id, string username, string senha, List<Claim> claims) : base(id)
        {
            Username = username;
            Password = senha;
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