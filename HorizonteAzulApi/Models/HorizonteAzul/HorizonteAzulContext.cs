using Microsoft.EntityFrameworkCore;

namespace HorizonteAzulApi.Models.HorizonteAzul
{
    public class HorizonteAzulContext(DbContextOptions<HorizonteAzulContext> options) : DbContext(options)
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<TipoUsuario> TipoUsuario { get; set; }
        public DbSet<SituacaoUsuario> SituacaoUsuario { get; set; }
        public DbSet<Sessao> Sessao { get; set; }
    }
}
