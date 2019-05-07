using Jurify.Autenticador.Web.Domain.Model.Entities;
using Jurify.Autenticador.Web.Domain.Model.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Jurify.Autenticador.Web.Infrastructure.Database.Configuration
{
    public class ClientUserTypeConfiguration : IEntityTypeConfiguration<ClientUser>
    {
        public void Configure(EntityTypeBuilder<ClientUser> builder)
        {
            builder.ToTable("client_users");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.Username).HasColumnName("username");
            builder.Property(e => e.Password).HasColumnName("password");

            builder.OwnsOne(e => e.PersonalInfo, b =>
            {
                b.Property(e => e.FirstName).HasColumnName("first_name");
                b.Property(e => e.LastName).HasColumnName("last_name");
            });
            builder.Property(e => e.Claims)
                .HasColumnName("claims")
                .HasColumnType("jsonb")
                .HasConversion(
                    v => JsonConvert.SerializeObject(v),
                    v => JsonConvert.DeserializeObject<List<Claim>>(v)
                );

            builder.Property(e => e.Deleted).HasColumnName("deleted");
            builder.HasQueryFilter(e => !e.Deleted);
        }
    }
}
