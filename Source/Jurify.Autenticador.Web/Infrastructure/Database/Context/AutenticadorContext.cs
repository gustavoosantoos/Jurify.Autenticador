using Jurify.Autenticador.Web.Domain.Model.Entities;
using Jurify.Autenticador.Web.Infrastructure.Database.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Jurify.Autenticador.Web.Infrastructure.Database.Context
{
    public class AutenticadorContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public AutenticadorContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public DbSet<Escritorio> Escritorios { get; private set; }
        public DbSet<UsuarioEscritorio> UsuariosEscritorio { get; private set; }
        public DbSet<UsuarioCliente> UsuariosCliente { get; private set; }
        public DbSet<Especialidade> Especialidades { get; private set; }
        public DbSet<EspecialidadesEscritorio> EspecialidadesEscritorio { get; private set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_configuration.GetConnectionString("Default"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EscritorioTypeConfiguration());
            modelBuilder.ApplyConfiguration(new UsuarioEscritorioTypeConfiguration());
            modelBuilder.ApplyConfiguration(new UsuarioClienteTypeConfiguration());
            modelBuilder.ApplyConfiguration(new EnderecoTypeConfiguration());
            modelBuilder.ApplyConfiguration(new EspecialidadeTypeConfiguration());
            modelBuilder.ApplyConfiguration(new EspecialidadesEscritorioTypeConfiguration());
        }
    }
}
