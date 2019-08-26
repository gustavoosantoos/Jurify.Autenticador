using Jurify.Autenticador.Web.Domain.Model.Base;
using System.Collections.Generic;

namespace Jurify.Autenticador.Web.Domain.Model.ValueObjects
{
    public class InformacoesDoEscritorio : ValueObject
    {
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; private set; }
        public string CNPJ { get; private set; }

        protected InformacoesDoEscritorio() { }

        public InformacoesDoEscritorio(string nomeFantasia, string razaoSocial, string cnpj)
        {
            NomeFantasia = nomeFantasia;
            RazaoSocial = razaoSocial;
            CNPJ = cnpj;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return NomeFantasia;
        }
    }
}
