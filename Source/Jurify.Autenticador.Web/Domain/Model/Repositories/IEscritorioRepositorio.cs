using Jurify.Autenticador.Web.Domain.Model.Entities;
using System;
using System.Threading.Tasks;

namespace Jurify.Autenticador.Web.Domain.Model.Repositories
{
    public interface IEscritorioRepositorio
    {
        Task<Escritorio> BuscarPorNomeAsync(string officeName);
        Task<Escritorio> BuscarPorIdAsync(Guid officeId);
    }
}
