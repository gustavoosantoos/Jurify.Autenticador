using System.Collections.Generic;
using Jurify.Autenticador.Domain.Base;

namespace Jurify.Autenticador.Domain.ValueObjects
{
    public class TelefoneContato : ValueObject
    {
        public int DDD { get; }
        public int Numero { get; }

        public TelefoneContato(int ddd, int numero)
        {
            DDD = ddd;
            Numero = numero;
        }

        protected override IEnumerable<object> ObterComponentesDeIgualdade()
        {
            yield return DDD;
            yield return Numero;
        }
    }
}
