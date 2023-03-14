using VoleyPlaya.Repository.Models;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace VoleyPlaya.Repository
{
    public class VoleyPlayaDbContext : IdentityDbContext<VoleyPlayaApplicationUser, IdentityRole, string>
    {
        private readonly IConfiguration _configuration;

        public DbSet<Temporada> Temporadas { get; set; }
        public DbSet<Competicion> Competiciones { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Edicion> Ediciones { get; set; }
        public DbSet<Equipo> Equipos { get; set; }
        public DbSet<Partido> Partidos { get; set; }
        public DbSet<ParcialPartido> Parciales { get; set; }

        public VoleyPlayaDbContext(DbContextOptions<VoleyPlayaDbContext> options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder == null) return;
            optionsBuilder.EnableSensitiveDataLogging();
            // connect to sql server database
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DatabaseConnection"));

            base.OnConfiguring(optionsBuilder);
        }
    }
}