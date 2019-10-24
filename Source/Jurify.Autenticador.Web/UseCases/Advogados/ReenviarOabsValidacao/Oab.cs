using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jurify.Autenticador.Web.UseCases.Lawyers.ResendValidateOab
{
    public class Oab
    {
        public Guid CodigoAdvogado { get; set; }
        public string NumeroOab { get; set; }
        public string Uf { get; set; }
        public string NomeCompleto { get; set; }

        public Oab(Guid codigoAdvogado, string numeroOab, string uf, string nomeCompleto)
        {
            CodigoAdvogado = codigoAdvogado;
            NumeroOab = numeroOab;
            Uf = uf;
            NomeCompleto = nomeCompleto;
        }

        public Oab()
        {
        }
    }
}
