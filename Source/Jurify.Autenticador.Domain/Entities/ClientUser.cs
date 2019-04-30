namespace Jurify.Autenticador.Domain.Entities
{
    public class ClientUser : User
    {
        public ClientUser(string username, string senha) : base(username, senha)
        {
        }
    }
}
