using Jurify.Autenticador.Web.Domain.Model.Base;
using System;

namespace Jurify.Autenticador.Web.Domain.Model.Entities
{
    public class Endereco : Entity
    {
        public Guid CodigoEscritorio { get; set; }
        public Escritorio Escritorio { get; set; }

        public string CEP { get; set; }
        public string Rua { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
