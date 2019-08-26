using Jurify.Autenticador.Web.Domain.Model.Entities;
using System.Threading.Tasks;

namespace Jurify.Autenticador.Web.UseCases.Services.Abstractions
{
    public interface IEscritorioServico
    {
        Task<Escritorio> BuscarPorNomeAsync(string nomeFantasia);
    }
}
