using Jurify.Autenticador.Domain.Base;

namespace Jurify.Autenticador.Domain.Entities
{
    public abstract class Usuario : Entity
    {
        public string Username { get; }
        public string Senha { get; private set; }

        public Usuario(string username, string senha)
        {
            Username = username;
            Senha = senha;
        }

        public void AtualizarSenha(string novaSenha)
        {
            Senha = novaSenha;
        }
    }
}
