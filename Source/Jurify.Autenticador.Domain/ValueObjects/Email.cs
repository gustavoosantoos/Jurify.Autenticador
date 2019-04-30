using Jurify.Autenticador.Domain.Base;
using System;

namespace Jurify.Autenticador.Domain.ValueObjects
{
    public class EmailContato : ValueObject<EmailContato>
    {
        public string Email { get; }

        public EmailContato(string email)
        {
            Email = email;
        }

        protected override bool EqualsCore(EmailContato other)
        {
            return Email == other.Email;
        }

        protected override int GetHashCodeCore()
        {
            return HashCode.Combine(Email);
        }
    }
}
