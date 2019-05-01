using Jurify.Autenticador.Domain.Base;
using System;
using System.Collections.Generic;

namespace Jurify.Autenticador.Domain.ValueObjects
{
    public class ContactEmail : ValueObject
    {
        public string Email { get; private set; }

        protected ContactEmail() { }

        public ContactEmail(string email)
        {
            Email = email;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Email;
        }
    }
}
