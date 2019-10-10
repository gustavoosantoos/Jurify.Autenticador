using System;

namespace Jurify.Autenticador.Web.UseCases.Lawyers.CreateInitial
{
    public class Usuario
    {
        public Guid CodigoUsuario { get; set; }
        public Guid CodigoEscritorio { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public int Estado { get; set; }
        public string NumeroOAB { get; set; }
        public string ehAdministrador { get; set; }
    }
}
