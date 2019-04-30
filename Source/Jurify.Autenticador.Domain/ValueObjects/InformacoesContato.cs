using Jurify.Autenticador.Domain.Base;
using System;

namespace Jurify.Autenticador.Domain.ValueObjects
{
    public class InformacoesContato : ValueObject<InformacoesContato>
    {
        public EmailContato Email { get; }
        public TelefoneContato Telefone { get; }

        public InformacoesContato(EmailContato email, TelefoneContato telefone)
        {
            Email = email;
            Telefone = telefone;
        }

        protected override bool EqualsCore(InformacoesContato other)
        {
            return Email == other.Email &&
                Telefone == other.Telefone;
        }

        protected override int GetHashCodeCore()
        {
            return HashCode.Combine(Email, Telefone);
        }
    }
}
