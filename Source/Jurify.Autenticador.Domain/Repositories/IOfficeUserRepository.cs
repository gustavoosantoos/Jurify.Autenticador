using Jurify.Autenticador.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Jurify.Autenticador.Domain.Repositories
{
    public interface IOfficeUserRepository
    {
        Task<OfficeUser> FindByIdAsync(Guid id);
        Task<OfficeUser> FindByUsernameAsync(string username);
        Task<bool> ExistsAsync(Guid id);
        Task<bool> ExistsAsync(string username, string password);
    }
}
