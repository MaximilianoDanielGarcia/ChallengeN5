using ChallengeN5.Interfaces;
using ChallengeN5.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace ChallengeN5.Context
{
    public class N5DbContext : DbContext, IN5DbContext
    {
        public N5DbContext(DbContextOptions<N5DbContext> options) : base(options) { }

        public DbSet<Permiso> Permisos { get; set; }

        public DbSet<TipoPermiso> TipoPermisos { get; set; }

        public new async Task<int> SaveChanges()
        {
            return await base.SaveChangesAsync();
        }

        public void Entry<T>(T entity, EntityState entityState)
        {
            base.Entry(entity).State = entityState;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(
                    @"Server=.;Database=ChallengeN5;TrustServerCertificate=True;Integrated Security=True;ConnectRetryCount=0",
                    options => options.EnableRetryOnFailure());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Permiso>()
                .Property(p => p.TipoPermisoId)
                .HasColumnName("TipoPermiso");

            modelBuilder.Entity<TipoPermiso>()
                .Property(t => t.Id)
                .ValueGeneratedOnAdd();

        }
    }
}
