using Jurify.Autenticador.Web.Domain.Model.Base;
using Jurify.Autenticador.Web.Domain.Model.Exceptions;
using System.Collections.Generic;

namespace Jurify.Autenticador.Web.Domain.Model.ValueObjects
{
    public class OfficeLocation : ValueObject
    {
        public double? Latitude { get; private set; }
        public double? Longitude { get; private set; }
        public bool IsActive { get; private set; }

        protected OfficeLocation() { }

        public OfficeLocation(double? latitude, double? longitude)
        {
            if (!latitude.HasValue || !longitude.HasValue)
            {
                IsActive = false;
            }
            else
            {
                IsActive = true;
                Latitude = latitude;
                Longitude = longitude;
            }
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Latitude;
            yield return Longitude;
        }
    }
}
