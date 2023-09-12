using ChallengeN5.Interfaces;
using ChallengeN5.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ChallengeN5.Context;

public class ChallengeN5Context : DbContext, IChallengeN5Context
{
    public ChallengeN5Context()
    {
    }

    public ChallengeN5Context(DbContextOptions<ChallengeN5Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Permiso> Permisos { get; set; }

    public virtual DbSet<TipoPermiso> TipoPermisos { get; set; }

    public async Task<int> SaveChangesAsync()
    {
        return await base.SaveChangesAsync();
    }

    public new EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class
    {
        return base.Entry(entity);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=.;Database=ChallengeN5;TrustServerCertificate=True;Integrated Security=True;ConnectRetryCount=0");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Permiso>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Permisos__3214EC07AD08653F");

            entity.Property(e => e.ApellidoEmpleado)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FechaPermiso).HasColumnType("datetime");
            entity.Property(e => e.NombreEmpleado)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.TipoPermisoNavigation).WithMany(p => p.Permisos)
                .HasForeignKey(d => d.TipoPermiso)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Permisos__TipoPe__3E52440B");
        });

        modelBuilder.Entity<TipoPermiso>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TipoPerm__3214EC07DB319995");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

    }

}
