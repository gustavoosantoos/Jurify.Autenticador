using System.Threading.Tasks;

namespace Jurify.Autenticador.Web.Domain.Model.Services.Abstractions
{
    public interface IGeocodingService
    {
        Task<(double lat, double lon)> ObterCoordenadas(string endereco);
    }
}
