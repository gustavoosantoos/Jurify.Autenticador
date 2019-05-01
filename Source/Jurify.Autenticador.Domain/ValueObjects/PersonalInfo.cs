using Jurify.Autenticador.Domain.Base;
using System;
using System.Collections.Generic;

namespace Jurify.Autenticador.Domain.ValueObjects
{
    public class PersonalInfo : ValueObject
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        protected PersonalInfo() { }

        public PersonalInfo(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return FirstName;
            yield return LastName;
        }
    }
}
