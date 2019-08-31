using System.Collections.Generic;
using Jurify.Autenticador.Web.Domain.Model.Base;
using Jurify.Autenticador.Web.Domain.Model.Enums;

namespace Jurify.Autenticador.Web.Domain.Model.ValueObjects
{
    public class CredenciaisAdvogado : ValueObject
    {
        public CredenciaisAdvogado(string numeroOab, EstadoBrasileiro estado, string caminhoFoto)
        {
            NumeroOab = numeroOab;
            Estado = estado;
            CaminhoFoto = caminhoFoto;
        }

        public string NumeroOab { get; set; }
        public EstadoBrasileiro Estado { get; set; }
        public string CaminhoFoto { get; set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return NumeroOab;
            yield return Estado;
            yield return CaminhoFoto;
        }
    }
}
