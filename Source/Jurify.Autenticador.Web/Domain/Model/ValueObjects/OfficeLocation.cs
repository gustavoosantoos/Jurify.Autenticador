using Jurify.Autenticador.Web.Domain.Model.Base;
using System.Collections.Generic;

namespace Jurify.Autenticador.Web.Domain.Model.ValueObjects
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
