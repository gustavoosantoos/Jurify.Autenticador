using System;

namespace Jurify.Autenticador.Domain.Entities
{
    public class ClientUser : User
    {
        public ClientUser(Guid id, string username, string senha) 
            : base(id, username, senha)
        {
        }
    }
}
