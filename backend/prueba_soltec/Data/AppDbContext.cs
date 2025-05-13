using Microsoft.EntityFrameworkCore;
using prueba_soltec.Models;
using Npgsql.EntityFrameworkCore.PostgreSQL;

namespace prueba_soltec.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.HasIndex(p => p.Email).IsUnique();
            });
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Usuarios> Usuarios { get; set; } = null;
    }
}
