using Jurify.Autenticador.Web.Domain.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jurify.Autenticador.Web.Infrastructure.Database.Configuration
{
    public class EscritorioTypeConfiguration : IEntityTypeConfiguration<Escritorio>
    {
        public void Configure(EntityTypeBuilder<Escritorio> builder)
        {
            builder.ToTable("offices");
            builder.HasKey(e => e.Codigo);

            builder.Property(e => e.Codigo).HasColumnName("id");

            builder.OwnsOne(e => e.Informacoes, b =>
            {
                b.Property(e => e.NomeFantasia).HasColumnName("name");
            });

            builder.HasMany(e => e.Usuarios).WithOne(u => u.Office).HasForeignKey(u => u.CodigoEscritorio);

            builder.Property(e => e.Apagado).HasColumnName("deleted");

            builder.HasQueryFilter(e => !e.Apagado);
        }
    }
}
