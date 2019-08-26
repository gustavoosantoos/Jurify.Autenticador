using Jurify.Autenticador.Web.Domain.Model.ValueObjects;
using System;
using System.Collections.Generic;

namespace Jurify.Autenticador.Web.Domain.Model.Entities
{
    public class UsuarioCliente : Usuario
    {
        public UsuarioCliente(Guid id,
                          string username,
                          string senha,
                          InformacoesPessoais informacoesPessoais,
                          List<Permissao> permissoes) : base(id, username, senha, informacoesPessoais, permissoes)
        {
        }

        protected UsuarioCliente()
        {
        }
    }
}
