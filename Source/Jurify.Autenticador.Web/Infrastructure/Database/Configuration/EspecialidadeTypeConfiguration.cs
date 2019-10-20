using Jurify.Autenticador.Web.Domain.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;

namespace Jurify.Autenticador.Web.Infrastructure.Database.Configuration
{
    public class EspecialidadeTypeConfiguration : IEntityTypeConfiguration<Especialidade>
    {
        public void Configure(EntityTypeBuilder<Especialidade> builder)
        {
            builder.ToTable("especialidades");
            builder.HasKey(e => e.Codigo);
            builder.Property(e => e.Codigo).HasColumnName("codigo");
            builder.Property(e => e.Nome).HasColumnName("nome");
            builder.Property(e => e.Descricao).HasColumnName("descricao");

            builder.Property(e => e.Apagado).HasColumnName("apagado");
            builder.HasQueryFilter(e => !e.Apagado);
        }
    }
}
