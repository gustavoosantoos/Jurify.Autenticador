using Jurify.Autenticador.Web.Domain.Model.Entities;
using System;
using System.Threading.Tasks;

namespace Jurify.Autenticador.Web.Domain.Model.Repositories
{
    public interface IOfficeUserRepository
    {
        Task<OfficeUser> FindByIdAsync(Guid id);
        Task<OfficeUser> FindByUsernameAsync(string username);
        Task<bool> ExistsAsync(Guid id);
        Task<bool> ExistsAsync(string username, string password);
    }
}
