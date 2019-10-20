using Jurify.Autenticador.Web.Domain.Model.Enums;
using Jurify.Autenticador.Web.Domain.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jurify.Autenticador.Web.UseCases.Advogados.ListarUsuariosDoEscritorio
{
    public class Usuario
    {
        public Guid CodigoEscritorio { get; private set; }
        public Guid CodigoUsuario { get; private set; }
        public string Email { get; private set; }
        public string PrimeiroNome { get; private set; }
        public string UltimoNome { get; private set; }
        public string NumeroOab { get; set; }
        public EstadoBrasileiro Estado { get; set; }
        public bool ehAdministrador { get; set; }

        public Usuario(UsuarioEscritorio user)
        {
            CodigoEscritorio = user.CodigoEscritorio;
            CodigoUsuario = user.Codigo;
            Email = user.Username;
            PrimeiroNome = user.InformacoesPessoais.PrimeiroNome;
            UltimoNome = user.InformacoesPessoais.UltimoNome;
            NumeroOab = user.Credenciais.NumeroOab;
            Estado = user.Credenciais.Estado;
            if (user.Permissoes != null && user.Permissoes.Exists(x => x.Nome.Equals("EhAdministrador")))
                ehAdministrador = bool.Parse(user.Permissoes.Find(x => x.Nome.Contains("EhAdministrador")).Valor);
            else
                ehAdministrador = false;
        }
    }
}
