using Jurify.Autenticador.Web.Domain.Model.Base;
using System;
using System.Collections.Generic;

namespace Jurify.Autenticador.Web.Domain.Model.ValueObjects
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
