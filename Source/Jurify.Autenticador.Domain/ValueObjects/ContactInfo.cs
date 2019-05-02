﻿using Jurify.Autenticador.Domain.Base;
using System;
using System.Collections.Generic;

namespace Jurify.Autenticador.Domain.ValueObjects
{
    public class ContactInfo : ValueObject
    {
        public ContactEmail Email { get; private set; }
        public PhoneNumber Phone { get; private set; }

        protected ContactInfo() { }

        public ContactInfo(ContactEmail email, PhoneNumber phone = null)
        {
            Email = email;
            Phone = phone ?? PhoneNumber.Empty();
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Email;
            yield return Phone;
        }
    }
}
