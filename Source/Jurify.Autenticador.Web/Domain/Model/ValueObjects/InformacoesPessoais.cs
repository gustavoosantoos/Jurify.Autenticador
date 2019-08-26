using Jurify.Autenticador.Web.Domain.Model.Base;
using System;
using System.Collections.Generic;

namespace Jurify.Autenticador.Web.Domain.Model.ValueObjects
{
    public class InformacoesPessoais : ValueObject
    {
        public string PrimeiroNome { get; private set; }
        public string UltimoNome { get; private set; }

        protected InformacoesPessoais() { }

        public InformacoesPessoais(string primeiroNome, string ultimoNome)
        {
            PrimeiroNome = primeiroNome;
            UltimoNome = ultimoNome;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return PrimeiroNome;
            yield return UltimoNome;
        }
    }
}
