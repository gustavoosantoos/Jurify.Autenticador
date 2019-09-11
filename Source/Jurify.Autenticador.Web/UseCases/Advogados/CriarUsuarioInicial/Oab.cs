using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jurify.Autenticador.Web.UseCases.Advogados.CriarUsuarioInicial
{
    public class Oab
    {
        public string NumeroOab { get; set; }
        public string Uf { get; set; }
        public string NomeCompleto { get; set; }

        public Oab(string numeroOab, string uf, string nomeCompleto)
        {
            NumeroOab = numeroOab;
            Uf = uf;
            NomeCompleto = nomeCompleto;
        }
    }
}
