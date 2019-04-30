using Jurify.Autenticador.Domain.Base;
using System;
using System.Collections.Generic;

namespace Jurify.Autenticador.Domain.ValueObjects
{
    public class InformacoesPessoais : ValueObject
    {
        public string PrimeiroNome { get; }
        public string UltimoNome { get; }

        public InformacoesPessoais(string primeiroNome, string ultimoNome)
        {
            PrimeiroNome = primeiroNome;
            UltimoNome = ultimoNome;
        }

        protected override IEnumerable<object> ObterComponentesDeIgualdade()
        {
            yield return PrimeiroNome;
            yield return UltimoNome;
        }
    }
}
