using System;
using System.Collections.Generic;

namespace Jurify.Autenticador.Web.UseCases.Clientes.ListarEscritorios
{
    public class Escritorio
    {
        public Guid Codigo { get; set; }
        public string RazaoSocial { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public string Endereco { get; set; }
        public IEnumerable<Especialidade> Especialidades { get; set; }
    }
}
