using Jurify.Autenticador.Web.Domain.Model.Base;
using System;

namespace Jurify.Autenticador.Web.Domain.Model.Entities
{
    public class Endereco : Entity
    {
        protected Endereco()
        {

        }

        public Endereco(string cep,
                        string rua,
                        string numero,
                        string complemento,
                        string bairro,
                        string cidade,
                        string estado,
                        double latitude,
                        double longitude)
        {
            CEP = cep;
            Rua = rua;
            Numero = numero;
            Complemento = complemento;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
            Latitude = latitude;
            Longitude = longitude;
        }

        public void AtualizarDadosEndereco(string cep,
                        string rua,
                        string numero,
                        string complemento,
                        string bairro,
                        string cidade,
                        string estado,
                        double latitude,
                        double longitude)
        {
            CEP = cep;
            Rua = rua;
            Numero = numero;
            Complemento = complemento;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
            Latitude = latitude;
            Longitude = longitude;
        }

        public Guid CodigoEscritorio { get; set; }
        public Escritorio Escritorio { get; set; }

        public string CEP { get; private set; }
        public string Rua { get; private set; }
        public string Numero { get; private set; }
        public string Complemento { get; private set; }
        public string Bairro { get; private set; }
        public string Cidade { get; private set; }
        public string Estado { get; private set; }
        public double? Latitude { get; private set; }
        public double? Longitude { get; private set; }
    }
}
