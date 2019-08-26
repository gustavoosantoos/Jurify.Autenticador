using Jurify.Autenticador.Web.Domain.Model.Base;
using Jurify.Autenticador.Web.Domain.Model.ValueObjects;
using System;
using System.Collections.Generic;

namespace Jurify.Autenticador.Web.Domain.Model.Entities
{
    public abstract class Usuario : Entity
    {
        public string Username { get; private set; }
        public string Senha { get; private set; }
        public InformacoesPessoais InformacoesPessoais { get; private set; }
        public List<Permissao> Permissoes { get; private set; }

        protected Usuario() : base(Guid.NewGuid())
        {
        }

        public Usuario(
            Guid id,
            string username,
            string senha,
            InformacoesPessoais informacoesPessoais,
            List<Permissao> permissoes) : base(id)
        {
            Username = username;
            Senha = senha;
            InformacoesPessoais = informacoesPessoais;
            Permissoes = permissoes;
        }

        public void AtualizarSenha(string novaSenha)
        {
            Senha = novaSenha;
        }

        public void AtualizarInformacoesPessoais(InformacoesPessoais novasInformacoes)
        {
            InformacoesPessoais = novasInformacoes;
        }
    }
}
