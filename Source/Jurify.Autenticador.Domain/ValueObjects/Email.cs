using Jurify.Autenticador.Domain.Base;
using System;
using System.Collections.Generic;

namespace Jurify.Autenticador.Domain.ValueObjects
{
    public class EmailContato : ValueObject
    {
        public string Email { get; }

        public EmailContato(string email)
        {
            Email = email;
        }

        protected override IEnumerable<object> ObterComponentesDeIgualdade()
        {
            yield return Email;
        }
    }
}
