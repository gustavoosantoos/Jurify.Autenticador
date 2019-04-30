using Jurify.Autenticador.Domain.Entities;
using Jurify.Autenticador.Domain.ValueObjects;

namespace Jurify.Autenticador.Domain.Model
{
    public class UsuarioEscritorio : Usuario
    {
        public IdentificadorEscritorio IdEscritorio { get; }

        public UsuarioEscritorio(IdentificadorEscritorio idEscritorio, string username, string senha) : base(username, senha)
        {
            IdEscritorio = idEscritorio;
        }
    }
}
