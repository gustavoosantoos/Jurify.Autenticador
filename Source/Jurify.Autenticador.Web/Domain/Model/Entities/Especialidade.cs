using Jurify.Autenticador.Web.Domain.Model.Base;
using System;

namespace Jurify.Autenticador.Web.Domain.Model.Entities
{
    public class Especialidade : Entity
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
       
        protected Especialidade()
        {
        }
        
        public Especialidade (string nome, string descricao) : base(Guid.NewGuid())
        {
            Nome = nome;
            Descricao = descricao;
        }
    }
}
