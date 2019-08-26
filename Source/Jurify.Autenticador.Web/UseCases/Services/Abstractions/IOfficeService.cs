using Jurify.Autenticador.Web.Domain.Model.Entities;
using System.Threading.Tasks;

namespace Jurify.Autenticador.Web.UseCases.Services.Abstractions
{
    public interface IOfficeService
    {
        Task<Escritorio> FindByNameAsync(string officeName);
    }
}
