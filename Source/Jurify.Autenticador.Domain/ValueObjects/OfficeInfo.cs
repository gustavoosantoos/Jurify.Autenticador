using Jurify.Autenticador.Domain.Base;
using System.Collections.Generic;

namespace Jurify.Autenticador.Domain.ValueObjects
{
    public class OfficeInfo : ValueObject
    {
        public string Name { get; private set; }

        protected OfficeInfo() { } 

        public OfficeInfo(string name)
        {
            Name = name;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Name;
        }
    }
}
