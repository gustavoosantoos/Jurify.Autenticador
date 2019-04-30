using Jurify.Autenticador.Domain.Base;
using System;
using System.Collections.Generic;

namespace Jurify.Autenticador.Domain.ValueObjects
{
    public class InformacoesContato : ValueObject
    {
        public EmailContato Email { get; }
        public TelefoneContato Telefone { get; }

        public InformacoesContato(EmailContato email, TelefoneContato telefone)
        {
            Email = email;
            Telefone = telefone;
        }

        protected override IEnumerable<object> ObterComponentesDeIgualdade()
        {
            yield return Email;
            yield return Telefone;
        }
    }
}
