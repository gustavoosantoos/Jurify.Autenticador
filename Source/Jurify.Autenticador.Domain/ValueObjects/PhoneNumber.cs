using System.Collections.Generic;
using Jurify.Autenticador.Domain.Base;

namespace Jurify.Autenticador.Domain.ValueObjects
{
    public class PhoneNumber : ValueObject
    {
        public int DDD { get; }
        public int Number { get; }

        public PhoneNumber(int ddd, int number)
        {
            DDD = ddd;
            Number = number;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return DDD;
            yield return Number;
        }
    }
}
