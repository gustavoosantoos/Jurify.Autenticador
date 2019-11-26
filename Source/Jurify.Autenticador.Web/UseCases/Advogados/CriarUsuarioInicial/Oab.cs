using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jurify.Autenticador.Web.UseCases.Advogados.CriarUsuarioInicial
{
    public class Oab
    {
        public int Codigo { get; set; }
        public Guid CodigoAdvogado { get; set; }
        public string NumeroOab { get; set; }
        public string Uf { get; set; }
        public string NomeCompleto { get; set; }
        public string CaminhoImagem { get; set; }
        public bool? Ativo { get; set; }
        public bool? Existe { get; set; }
        public bool Enviado { get; set; }
        public DateTime? DataEnvio { get; set; }

        public Oab(int codigo, Guid codigoAdvogado, string numeroOab, string uf, string nomeCompleto, string caminhoImagem, bool? ativo, bool? existe, bool enviado, DateTime? dataEnvio)
        {
            Codigo = codigo;
            CodigoAdvogado = codigoAdvogado;
            NumeroOab = numeroOab;
            Uf = uf;
            NomeCompleto = nomeCompleto;
            CaminhoImagem = caminhoImagem;
            Ativo = ativo;
            Existe = existe;
            Enviado = enviado;
            DataEnvio = dataEnvio;
        }

        public Oab(int codigo, Guid codigoAdvogado, string numeroOab, string uf, string nomeCompleto)
        {
            Codigo = codigo;
            CodigoAdvogado = codigoAdvogado;
            NumeroOab = numeroOab;
            Uf = uf;
            NomeCompleto = nomeCompleto;
        }
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
