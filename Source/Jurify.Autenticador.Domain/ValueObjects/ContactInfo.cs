using Jurify.Autenticador.Domain.Base;
using System;
using System.Collections.Generic;

namespace Jurify.Autenticador.Domain.ValueObjects
{
    public class ContactInfo : ValueObject
    {
        public ContactEmail Email { get; }
        public PhoneNumber Phone { get; }

        public ContactInfo(ContactEmail email, PhoneNumber phone)
        {
            Email = email;
            Phone = phone;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Email;
            yield return Phone;
        }
    }
}
