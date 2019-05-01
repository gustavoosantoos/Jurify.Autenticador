using Jurify.Autenticador.Domain.Base;
using System.Collections.Generic;

namespace Jurify.Autenticador.Domain.ValueObjects
{
    public class OfficeLocation : ValueObject
    {
        public double Latitude { get; private set; }
        public double Longitude { get; private set; }

        protected OfficeLocation() { }

        public OfficeLocation(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Latitude;
            yield return Longitude;
        }
    }
}
