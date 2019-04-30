using System;
using System.Collections.Generic;
using System.Linq;

namespace Jurify.Autenticador.Domain.Base
{
    public abstract class ValueObject
    {
        protected abstract IEnumerable<object> ObterComponentesDeIgualdade();

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (GetType() != obj.GetType())
                return false;

            var valueObject = (ValueObject)obj;

            return ObterComponentesDeIgualdade().SequenceEqual(valueObject.ObterComponentesDeIgualdade());
        }

        public override int GetHashCode()
        {
            var hashCode = new HashCode();
            ObterComponentesDeIgualdade().ToList().ForEach(obj => hashCode.Add(obj));

            return hashCode.ToHashCode();
        }

        public static bool operator ==(ValueObject a, ValueObject b)
        {
            if (a is null && b is null)
                return true;

            if (a is null || b is null)
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(ValueObject a, ValueObject b)
        {
            return !(a == b);
        }
    }
}
