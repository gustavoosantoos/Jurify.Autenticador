using System.Collections.Generic;
using Jurify.Autenticador.Domain.Base;

namespace Jurify.Autenticador.Domain.ValueObjects
{
    public class Claim : ValueObject
    {
        public string Name { get; }
        public string Value { get; }

        public Claim(string name, string value)
        {
            Name = name;
            Value = value;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Name.ToUpper();
            yield return Value.ToUpper();
        }
    }
}
