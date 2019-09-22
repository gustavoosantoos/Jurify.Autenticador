using Geocoding;
using Geocoding.Google;
using Jurify.Autenticador.Web.Domain.Model.Services.Abstractions;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace Jurify.Autenticador.Web.Domain.Model.Services.Implementations
{
    public class GeocodingService : IGeocodingService
    {
        private readonly IConfiguration _configuration;

        public GeocodingService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<(double lat, double lon)> ObterCoordenadas(string endereco)
        {
            IGeocoder geocoder = new GoogleGeocoder(_configuration["Maps:ApiKey"]);
            var enderecos = await geocoder.GeocodeAsync(endereco);
            var resultado = enderecos.First();

            return (resultado.Coordinates.Latitude, resultado.Coordinates.Longitude);
        }
    }
}
