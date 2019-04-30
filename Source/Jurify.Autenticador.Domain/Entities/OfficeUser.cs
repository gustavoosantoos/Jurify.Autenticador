using Jurify.Autenticador.Domain.Entities;
using Jurify.Autenticador.Domain.ValueObjects;

namespace Jurify.Autenticador.Domain.Model
{
    public class OfficeUser : User
    {
        public OfficeIdentifier OfficeId { get; }

        public OfficeUser(OfficeIdentifier officeId, string username, string password) : base(username, password)
        {
            OfficeId = officeId;
        }
    }
}
