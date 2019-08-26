﻿using Jurify.Autenticador.Web.Domain.Model.Base;
using Jurify.Autenticador.Web.Domain.Model.ValueObjects;
using System;
using System.Collections.Generic;

namespace Jurify.Autenticador.Web.Domain.Model.Entities
{
    public class Escritorio : Entity
    {
        protected Escritorio() : base(Guid.NewGuid())
        {
        }

        public Escritorio(InformacoesDoEscritorio info) : base(Guid.NewGuid())
        {
            Informacoes = info;
        }

        public InformacoesDoEscritorio Informacoes { get; private set; }
        public Endereco Endereco { get; private set; }
        public List<UsuarioEscritorio> Usuarios { get; private set; }
    }
}
