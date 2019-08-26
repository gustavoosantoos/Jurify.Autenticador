using Jurify.Autenticador.Web.Domain.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;

namespace Jurify.Autenticador.Web.Infrastructure.Database.Configuration
{
    public class EnderecoTypeConfiguration : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.ToTable("enderecos");
            builder.HasKey(e => e.Codigo);

            builder.Property(e => e.Codigo).HasColumnName("codigo");
            builder.Property(e => e.CEP).HasColumnName("cep");
            builder.Property(e => e.Rua).HasColumnName("rua");
            builder.Property(e => e.Numero).HasColumnName("numero");
            builder.Property(e => e.Complemento).HasColumnName("complemento");
            builder.Property(e => e.Bairro).HasColumnName("bairro");
            builder.Property(e => e.Cidade).HasColumnName("cidade");
            builder.Property(e => e.Estado).HasColumnName("estado");

            builder.Property(e => e.Latitude)
                .HasColumnName("latitude")
                .HasConversion(new NumberToStringConverter<double>());

            builder.Property(e => e.Longitude)
                .HasColumnName("longitude")
                .HasConversion(new NumberToStringConverter<double>());

            builder.Property(e => e.CodigoEscritorio).HasColumnName("codigo_escritorio");

            builder.HasOne(e => e.Escritorio)
                .WithOne(e => e.Endereco)
                .HasForeignKey<Endereco>(e => e.CodigoEscritorio);
        }
    }
}
