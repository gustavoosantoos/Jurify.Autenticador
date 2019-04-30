using Jurify.Autenticador.Domain.Base;
using System;

namespace Jurify.Autenticador.Domain.ValueObjects
{
    public class InformacoesPessoais : ValueObject<InformacoesPessoais>
    {
        public string PrimeiroNome { get; }
        public string UltimoNome { get; }

        public InformacoesPessoais(string primeiroNome, string ultimoNome)
        {
            PrimeiroNome = primeiroNome;
            UltimoNome = ultimoNome;
        }

        protected override bool EqualsCore(InformacoesPessoais other)
        {
            return PrimeiroNome == other.PrimeiroNome &&
                UltimoNome == other.UltimoNome;
        }

        protected override int GetHashCodeCore()
        {
            return HashCode.Combine(PrimeiroNome, UltimoNome);
        }
    }
}
