using Jurify.Autenticador.Domain.Base;
using System;
using System.Collections.Generic;

namespace Jurify.Autenticador.Domain.ValueObjects
{
    public class IdentificadorEscritorio : ValueObject
    {
        public Guid Id { get; }

        public IdentificadorEscritorio(Guid identificador)
        {
            Id = identificador;
        }

        protected override IEnumerable<object> ObterComponentesDeIgualdade()
        {
            yield return Id;
        }
    }
}
