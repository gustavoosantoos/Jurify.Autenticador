using Jurify.Autenticador.Web.Domain.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jurify.Autenticador.Web.Domain.Model.Entities
{
    

    public class Especialidade : Entity
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public Especialidade()
        {

        }
        public Especialidade (string nome, string descricao) : base(Guid.NewGuid())
        {
            Nome = nome;
            Descricao = descricao;
        }

    }
}
