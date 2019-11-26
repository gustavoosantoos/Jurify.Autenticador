using Jurify.Autenticador.Web.Domain.Model.Entities;
using Jurify.Autenticador.Web.Infrastructure.Database.Configuration;
using Jurify.Autenticador.Web.UseCases.Advogados.CriarUsuarioInicial;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Jurify.Autenticador.Web.Infrastructure.Database.Context
{
    public class PerfilOabContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public PerfilOabContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public DbSet<Oab> Oab { get; private set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_configuration.GetConnectionString("PerfilOab"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Oab>(entity =>
            {
                entity.HasKey(e => e.Codigo)
                    .HasName("Oab_pkey");

                entity.Property(e => e.Codigo)
                    .HasColumnName("codigo")
                    .UseNpgsqlIdentityByDefaultColumn();

                entity.Property(e => e.Ativo).HasColumnName("ativo");

                entity.Property(e => e.CaminhoImagem)
                    .HasColumnName("caminhoImagem")
                    .HasDefaultValueSql("''::text");

                entity.Property(e => e.DataEnvio)
                    .HasColumnName("dataEnvio")
                    .HasColumnType("date");

                entity.Property(e => e.Enviado).HasColumnName("enviado");

                entity.Property(e => e.Existe).HasColumnName("existe");

                entity.Property(e => e.NomeCompleto).HasColumnName("nomeCompleto");

                entity.Property(e => e.NumeroOab)
                    .IsRequired()
                    .HasColumnName("numeroOab");

                entity.Property(e => e.Uf)
                    .IsRequired()
                    .HasColumnName("uf");
            });
        }
    }
}
