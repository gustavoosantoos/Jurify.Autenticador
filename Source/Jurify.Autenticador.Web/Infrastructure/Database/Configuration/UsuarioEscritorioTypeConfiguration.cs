using Jurify.Autenticador.Web.Domain.Model.Entities;
using Jurify.Autenticador.Web.Domain.Model.Enums;
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
            builder.ToTable("usuarios_escritorio");
            builder.HasKey(e => e.Codigo);

            builder.Property(e => e.Codigo).HasColumnName("codigo");
            builder.Property(e => e.Username).HasColumnName("username");
            builder.Property(e => e.Senha).HasColumnName("password");
            builder.Property(e => e.CodigoEscritorio).HasColumnName("codigo_escritorio");

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

            builder.OwnsOne(e => e.Credenciais, e =>
            {
                e.Property(c => c.NumeroOab).HasColumnName("numero_oab");
                e.Property(c => c.CaminhoFoto).HasColumnName("caminho_imagem");
                e.Property(c => c.Estado)
                    .HasColumnName("codigo_uf")
                    .HasConversion(
                        v => v.Codigo,
                        v => EstadoBrasileiro.ObterPorCodigo(v)
                    );
            });

            builder.Property(e => e.Apagado).HasColumnName("apagado");
            builder.HasQueryFilter(e => !e.Apagado);
        }
    }
}
