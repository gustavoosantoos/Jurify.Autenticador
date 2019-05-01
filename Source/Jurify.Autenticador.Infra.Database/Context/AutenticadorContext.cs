﻿using Jurify.Autenticador.Domain.Entities;
using Jurify.Autenticador.Infra.Database.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Jurify.Autenticador.Infra.Database.Context
{
    public class AutenticadorContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public AutenticadorContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public DbSet<Office> Offices { get; private set; }
        public DbSet<OfficeUser> OfficeUsers { get; private set; }
        //public DbSet<ClientUser> ClientUsers { get; private set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_configuration.GetConnectionString("Default"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new OfficeTypeConfiguration());
            modelBuilder.ApplyConfiguration(new OfficeUserTypeConfiguration());
        }
    }
}
