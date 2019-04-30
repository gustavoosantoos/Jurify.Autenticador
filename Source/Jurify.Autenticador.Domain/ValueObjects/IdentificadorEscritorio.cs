using Jurify.Autenticador.Domain.Base;
using System;

namespace Jurify.Autenticador.Domain.ValueObjects
{
    public class IdentificadorEscritorio : ValueObject<IdentificadorEscritorio>
    {
        public Guid Id { get; }

        public IdentificadorEscritorio(Guid identificador)
        {
            Id = identificador;
        }

        protected override bool EqualsCore(IdentificadorEscritorio other)
        {
            return Id == other.Id;
        }

        protected override int GetHashCodeCore()
        {
            return HashCode.Combine(Id);
        }
    }
}
