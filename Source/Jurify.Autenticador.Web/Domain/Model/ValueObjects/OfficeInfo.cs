using Jurify.Autenticador.Web.Domain.Model.Base;
using System.Collections.Generic;

namespace Jurify.Autenticador.Web.Domain.Model.ValueObjects
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
