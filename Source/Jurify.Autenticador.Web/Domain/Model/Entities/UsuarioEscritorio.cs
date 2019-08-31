using Jurify.Autenticador.Web.Domain.Model.ValueObjects;
using System;
using System.Collections.Generic;

namespace Jurify.Autenticador.Web.Domain.Model.Entities
{
    public class UsuarioEscritorio : Usuario
    {
        public Guid CodigoEscritorio { get; private set; }
        public Escritorio Office { get; private set; }
        public CredenciaisAdvogado Credenciais { get; set; }

        protected UsuarioEscritorio()
        {
        }

        public UsuarioEscritorio(Guid officeId,
                          string username,
                          string senha,
                          InformacoesPessoais personalInfo,
                          List<Permissao> claims,
                          CredenciaisAdvogado credenciais) : base(Guid.NewGuid(), username, senha, personalInfo, claims)
        {
            CodigoEscritorio = officeId;
            Credenciais = credenciais;
        }
    }
}
