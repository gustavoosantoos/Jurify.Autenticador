using System;
using System.Collections.Generic;
using Jurify.Autenticador.Web.Domain.Model.Base;

namespace Jurify.Autenticador.Web.Domain.Model.ValueObjects
{
    public class Claim : ValueObject
    {
        public string Name { get; private set; }
        public string Value { get; private set; }

        protected Claim() { }

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
