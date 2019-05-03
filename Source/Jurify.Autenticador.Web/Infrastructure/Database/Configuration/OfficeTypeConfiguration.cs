using Jurify.Autenticador.Web.Domain.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jurify.Autenticador.Web.Infrastructure.Database.Configuration
{
    public class OfficeTypeConfiguration : IEntityTypeConfiguration<Office>
    {
        public void Configure(EntityTypeBuilder<Office> builder)
        {
            builder.ToTable("offices");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id).HasColumnName("id");

            builder.OwnsOne(e => e.Info, b =>
            {
                b.Property(e => e.Name).HasColumnName("name");
            });

            builder.OwnsOne(e => e.Location, b =>
            {
                b.Property(e => e.Latitude).HasColumnName("latitude");
                b.Property(e => e.Longitude).HasColumnName("longitude");
            });

            builder.Property(e => e.Deleted).HasColumnName("deleted");

            builder.HasQueryFilter(e => !e.Deleted);
        }
    }
}
