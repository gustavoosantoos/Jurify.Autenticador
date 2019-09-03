using System.Collections.Generic;
using System.Linq;
using Jurify.Autenticador.Web.Domain.Model.Base;

namespace Jurify.Autenticador.Web.Domain.Model.Enums
{
    public class EstadoBrasileiro : ValueObject
    {
        public static readonly EstadoBrasileiro NAO_INFORMADO = new EstadoBrasileiro(0, "Não informado", string.Empty);
        public static readonly EstadoBrasileiro ACRE = new EstadoBrasileiro(1, "Acre", "AC");
        public static readonly EstadoBrasileiro ALAGOAS = new EstadoBrasileiro(2, "Alagoas", "AL");
        public static readonly EstadoBrasileiro AMAPA = new EstadoBrasileiro(3, "Amapá", "AP");
        public static readonly EstadoBrasileiro AMAZONAS = new EstadoBrasileiro(4, "Amazonas", "AM");
        public static readonly EstadoBrasileiro BAHIA = new EstadoBrasileiro(5, "Bahia", "BA");
        public static readonly EstadoBrasileiro CEARA = new EstadoBrasileiro(6, "Ceará", "CE");
        public static readonly EstadoBrasileiro DISTRITO_FEDERAL = new EstadoBrasileiro(7, "Distrito Federal", "DF");
        public static readonly EstadoBrasileiro ESPIRITO_SANTO = new EstadoBrasileiro(8, "Espírito Santo", "ES");
        public static readonly EstadoBrasileiro GOIAS = new EstadoBrasileiro(9, "Goiás", "GO");
        public static readonly EstadoBrasileiro MARANHAO = new EstadoBrasileiro(10, "Maranhão", "MA");
        public static readonly EstadoBrasileiro MATO_GROSSO = new EstadoBrasileiro(11, "Mato Grosso", "MT");
        public static readonly EstadoBrasileiro MATO_GROSSO_DO_SUL = new EstadoBrasileiro(12, "Mato Grosso do Sul", "MS");
        public static readonly EstadoBrasileiro MINAS_GERAIS = new EstadoBrasileiro(13, "Minas Gerais", "MG");
        public static readonly EstadoBrasileiro PARA = new EstadoBrasileiro(14, "Pará", "PA");
        public static readonly EstadoBrasileiro PARAIBA = new EstadoBrasileiro(15, "Paraíba", "PB");
        public static readonly EstadoBrasileiro PARANA = new EstadoBrasileiro(16, "Paraná", "PR");
        public static readonly EstadoBrasileiro PERNAMBUCO = new EstadoBrasileiro(17, "Pernambuco", "PE");
        public static readonly EstadoBrasileiro PIAUI = new EstadoBrasileiro(18, "Piauí", "PI");
        public static readonly EstadoBrasileiro RIO_DE_JANEIRO = new EstadoBrasileiro(19, "Rio de Janeiro", "RJ");
        public static readonly EstadoBrasileiro RIO_GRANDE_DO_NORTE = new EstadoBrasileiro(20, "Rio Grande do Norte", "RN");
        public static readonly EstadoBrasileiro RIO_GRANDE_DO_SUL = new EstadoBrasileiro(21, "Rio Grande do Sul", "RS");
        public static readonly EstadoBrasileiro RONDONIA = new EstadoBrasileiro(22, "Rondônia", "RO");
        public static readonly EstadoBrasileiro RORAIMA = new EstadoBrasileiro(23, "Roraima", "RR");
        public static readonly EstadoBrasileiro SANTA_CATARINA = new EstadoBrasileiro(24, "Santa Catarina", "SC");
        public static readonly EstadoBrasileiro SAO_PAULO = new EstadoBrasileiro(25, "São Paulo", "SP");
        public static readonly EstadoBrasileiro SERGIPE = new EstadoBrasileiro(26, "Sergipe", "SE");
        public static readonly EstadoBrasileiro TOCANTINS = new EstadoBrasileiro(27, "Tocantins", "TO");

        private EstadoBrasileiro(int codigo, string nome, string uf)
        {
            Codigo = codigo;
            Nome = nome;
            UF = uf;
        }

        public int Codigo { get; private set; }
        public string Nome { get; private set; }
        public string UF { get; private set; }

        public static IEnumerable<EstadoBrasileiro> ObterTodos()
        {
            return new List<EstadoBrasileiro>
            {
                NAO_INFORMADO,
                ACRE,
                ALAGOAS,
                AMAPA,
                AMAZONAS,
                BAHIA,
                CEARA,
                DISTRITO_FEDERAL,
                ESPIRITO_SANTO,
                GOIAS,
                MARANHAO,
                MATO_GROSSO,
                MATO_GROSSO_DO_SUL,
                MINAS_GERAIS,
                PARA,
                PARAIBA,
                PARANA,
                PERNAMBUCO,
                PIAUI,
                RIO_DE_JANEIRO,
                RIO_GRANDE_DO_NORTE,
                RIO_GRANDE_DO_SUL,
                RONDONIA,
                RORAIMA,
                SANTA_CATARINA,
                SAO_PAULO,
                SERGIPE,
                TOCANTINS
            };
        }

        public static EstadoBrasileiro ObterPorUF(string uf)
        {
            return ObterTodos().FirstOrDefault(e => e.UF == uf) ?? NAO_INFORMADO;
        }

        public static EstadoBrasileiro ObterPorCodigo(int codigo)
        {
            return ObterTodos().FirstOrDefault(e => e.Codigo == codigo) ?? NAO_INFORMADO;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Codigo;
            yield return Nome;
            yield return UF;
        }
    }
}
