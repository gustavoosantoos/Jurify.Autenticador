using Jurify.Autenticador.Web.Domain.Model.Base;
using System;

namespace Jurify.Autenticador.Web.Domain.Model.Entities
{
    public class EspecialidadesEscritorio : Entity
    {
        public Guid CodigoEspecialidade { get; private set; }
        public Especialidade Especialidade { get; private set; }

        public Guid CodigoEscritorio { get; private set; }
        public Escritorio Escritorio { get; private set; }

        public string Nome { get; set; }
        public string Descricao { get; set; }

        public EspecialidadesEscritorio()
        {

        }
        public EspecialidadesEscritorio (Guid codigoEspecialidade, Guid codigoEscritorio) : base(Guid.NewGuid())
        {
            CodigoEspecialidade = codigoEspecialidade;
            CodigoEscritorio = codigoEscritorio;
        }
    }
}
