using Jurify.Autenticador.Web.Domain.Model.Entities;
using System;
using System.Threading.Tasks;

namespace Jurify.Autenticador.Web.Domain.Model.Repositories
{
    public interface IOfficeRepository
    {
        Task<Office> FindByNameAsync(string officeName);
        Task<Office> FindByIdAsync(Guid officeId);
    }
}
