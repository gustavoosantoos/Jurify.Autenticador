using Jurify.Autenticador.Web.Domain.Model.Entities;
using Jurify.Autenticador.Web.Domain.Model.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Jurify.Autenticador.Web.Infrastructure.Database.Configuration
{
    public class UsuarioEscritorioTypeConfiguration : IEntityTypeConfiguration<UsuarioEscritorio>
    {
        public void Configure(EntityTypeBuilder<UsuarioEscritorio> builder)
        {
            builder.ToTable("office_users");
            builder.HasKey(e => e.Codigo);

            builder.Property(e => e.Codigo).HasColumnName("id");
            builder.Property(e => e.Username).HasColumnName("username");
            builder.Property(e => e.Senha).HasColumnName("password");
            builder.Property(e => e.CodigoEscritorio).HasColumnName("office_id");

            builder.OwnsOne(e => e.InformacoesPessoais, b =>
            {
                b.Property(e => e.PrimeiroNome).HasColumnName("first_name");
                b.Property(e => e.UltimoNome).HasColumnName("last_name");
            });

            builder.Property(e => e.Permissoes)
                .HasColumnName("claims")
                .HasColumnType("jsonb")
                .HasConversion(
                    v => JsonConvert.SerializeObject(v),
                    v => JsonConvert.DeserializeObject<List<Permissao>>(v)
                );

            builder.Property(e => e.Apagado).HasColumnName("deleted");
            builder.HasQueryFilter(e => !e.Apagado);
        }
    }
}
