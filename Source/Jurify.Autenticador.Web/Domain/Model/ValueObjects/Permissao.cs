using System;
using System.Collections.Generic;
using Jurify.Autenticador.Web.Domain.Model.Base;

namespace Jurify.Autenticador.Web.Domain.Model.ValueObjects
{
    public class Permissao : ValueObject
    {
        public string Nome { get; private set; }
        public string Valor { get; private set; }

        protected Permissao() { }

        public Permissao(string nome, string valor)
        {
            Nome = nome;
            Valor = valor;
        }

        public void ConcedePermissao()
        {
            Valor = "true";
        }
        public void RetiraPermissao()
        {
            Valor = "false";
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Nome.ToUpper();
            yield return Valor.ToUpper();
        }
    }
}
