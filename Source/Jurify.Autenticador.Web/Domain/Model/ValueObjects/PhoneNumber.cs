using System.Collections.Generic;
using Jurify.Autenticador.Web.Domain.Model.Base;

namespace Jurify.Autenticador.Web.Domain.Model.ValueObjects
{
    public class PhoneNumber : ValueObject
    {
        public int DDD { get; private set; }
        public int Number { get; private set; }

        protected PhoneNumber() { }

        public PhoneNumber(int ddd, int number)
        {
            DDD = ddd;
            Number = number;
        }

        public static PhoneNumber Empty() => new PhoneNumber();

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return DDD;
            yield return Number;
        }
    }
}
