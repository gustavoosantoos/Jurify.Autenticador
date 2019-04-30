using Jurify.Autenticador.Domain.Base;
using Jurify.Autenticador.Domain.ValueObjects;

namespace Jurify.Autenticador.Domain.Entities
{
    public abstract class Usuario : Entity
    {
        public string Username { get; }
        public string Senha { get; private set; }
        public InformacoesContato Contato { get; private set; }
        public InformacoesPessoais InformacoesPessoais { get; private set; }

        public Usuario(string username, string senha)
        {
            Username = username;
            Senha = senha;
        }

        public void AtualizarSenha(string novaSenha)
        {
            Senha = novaSenha;
        }

        public void AtualizarContato(InformacoesContato contato)
        {
            Contato = contato;
        }

        public void AtualizarInformacoesPessoais(InformacoesPessoais informacoes)
        {
            InformacoesPessoais = informacoes;
        }
    }
}
