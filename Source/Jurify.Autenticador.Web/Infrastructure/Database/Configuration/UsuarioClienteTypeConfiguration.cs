using Jurify.Autenticador.Web.Domain.Model.Entities;
using Jurify.Autenticador.Web.Domain.Model.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Jurify.Autenticador.Web.Infrastructure.Database.Configuration
{
    public class UsuarioClienteTypeConfiguration : IEntityTypeConfiguration<UsuarioCliente>
    {
        public void Configure(EntityTypeBuilder<UsuarioCliente> builder)
        {
            builder.ToTable("usuarios_cliente");
            builder.HasKey(e => e.Codigo);

            builder.Property(e => e.Codigo).HasColumnName("codigo");
            builder.Property(e => e.Username).HasColumnName("username");
            builder.Property(e => e.Senha).HasColumnName("password");

            builder.OwnsOne(e => e.InformacoesPessoais, b =>
            {
                b.Property(e => e.PrimeiroNome).HasColumnName("nome");
                b.Property(e => e.UltimoNome).HasColumnName("sobrenome");
            });
            builder.Property(e => e.Permissoes)
                .HasColumnName("permissoes")
                .HasColumnType("jsonb")
                .HasConversion(
                    v => JsonConvert.SerializeObject(v),
                    v => JsonConvert.DeserializeObject<List<Permissao>>(v)
                );

            builder.Property(e => e.Apagado).HasColumnName("apagado");
            builder.HasQueryFilter(e => !e.Apagado);
        }
    }
}
