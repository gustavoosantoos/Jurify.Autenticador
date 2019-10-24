using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jurify.Autenticador.Web.UseCases.Lawyers.ValidateOab
{
    public class OabValidada
    {
        public Guid CodigoAdvogado { get; set; }
        public string NumeroOab { get; set; }
        public string Uf { get; set; }
        public string CaminhoImagem { get; set; }
        public bool? Ativo { get; set; }
        public bool? Existe { get; set; }

        public OabValidada(Guid codigoAdvogado,string uf,string numeroOab, string caminhoImagem, bool? ativo, bool? existe)
        {
            CodigoAdvogado = codigoAdvogado;
            NumeroOab = numeroOab;
            Uf = Uf;
            CaminhoImagem = caminhoImagem;
            Ativo = ativo;
            Existe = existe;
        }
    }
}
