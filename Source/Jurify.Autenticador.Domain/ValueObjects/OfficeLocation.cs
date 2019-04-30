using Jurify.Autenticador.Domain.Base;
using System.Collections.Generic;

namespace Jurify.Autenticador.Domain.ValueObjects
{
    public class OfficeLocation : ValueObject
    {
        public double Latitude { get; }
        public double Longitude { get; }

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
