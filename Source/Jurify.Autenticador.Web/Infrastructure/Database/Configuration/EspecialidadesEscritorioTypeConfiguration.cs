using Jurify.Autenticador.Web.Domain.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;

namespace Jurify.Autenticador.Web.Infrastructure.Database.Configuration
{
    public class EspecialidadesEscritorioTypeConfiguration : IEntityTypeConfiguration<EspecialidadesEscritorio>
    {
        public void Configure(EntityTypeBuilder<EspecialidadesEscritorio> builder)
        {
            builder.ToTable("especialidades_escritorio");
            builder.HasKey(e => e.Codigo);
            builder.Property(e => e.Codigo).HasColumnName("codigo");
            builder.Property(e => e.CodigoEspecialidade).HasColumnName("codigo_especialidade");
            builder.Property(e => e.CodigoEscritorio).HasColumnName("codigo_escritorio");

            builder.HasOne(e => e.Escritorio)
                   .WithMany(e => e.Especialidades)
                   .HasForeignKey(e => e.CodigoEscritorio);

            builder.HasOne(e => e.Especialidade)
                   .WithMany()
                   .HasForeignKey(e => e.CodigoEspecialidade);

            builder.Ignore(e => e.Nome);
            builder.Ignore(e => e.Descricao);

            builder.Property(e => e.Apagado).HasColumnName("apagado");
        }
    }
}
