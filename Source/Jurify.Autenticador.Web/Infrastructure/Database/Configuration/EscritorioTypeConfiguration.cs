using Jurify.Autenticador.Web.Domain.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jurify.Autenticador.Web.Infrastructure.Database.Configuration
{
    public class EscritorioTypeConfiguration : IEntityTypeConfiguration<Escritorio>
    {
        public void Configure(EntityTypeBuilder<Escritorio> builder)
        {
            builder.ToTable("escritorios");
            builder.HasKey(e => e.Codigo);

            builder.Property(e => e.Codigo).HasColumnName("codigo");

            builder.OwnsOne(e => e.Informacoes, b =>
            {
                b.Property(e => e.NomeFantasia).HasColumnName("nome_fantasia");
                b.Property(e => e.RazaoSocial).HasColumnName("razao_social");
                b.Property(e => e.CNPJ).HasColumnName("cnpj");
            });

            builder.HasMany(e => e.Usuarios).WithOne(u => u.Office).HasForeignKey(u => u.CodigoEscritorio);

            builder.Property(e => e.Apagado).HasColumnName("apagado");

            builder.HasQueryFilter(e => !e.Apagado);
        }
    }
}
