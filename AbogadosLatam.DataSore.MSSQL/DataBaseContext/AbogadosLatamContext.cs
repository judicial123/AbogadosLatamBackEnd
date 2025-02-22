using AbogadosLatam.DataSore.MSSQL.Model;
using AbogadosLatam.Domain;
using AbogadosLatam.Domain.Common;
using AbogadosLatam.Identity.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;


namespace AbogadosLatam.DataSore.MSSQL.DataBaseContext;

public class AbogadosLatamContext : DbContext
{
    public AbogadosLatamContext(DbContextOptions<AbogadosLatamContext> options) : base(options)
    {
        
    }
    
    public DbSet<PaisEntity> Paises { get; set; }
    public DbSet<CiudadEntity> Ciudades { get; set; }
    public DbSet<EspecialidadEntity> Especialidades { get; set; }
    public DbSet<EstudioEntity> Estudios { get; set; }
    public DbSet<SucursalEntity> Sucursales { get; set; }
    
    public DbSet<EstudioEspecialidadEntity> EstudioEspecialidades { get; set; }
    public DbSet<AbogadoEntity> Abogados { get; set; }
    public DbSet<ClienteEntity> Clientes { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AbogadosLatamContext).Assembly);
        
        modelBuilder.Entity<Pais>().HasData(
            new Pais
            {
                
                Id = 1,
                Nombre = "Ecuador",
                DateCreated = DateTime.Now,
                DateModified = DateTime.Now
            }
            );
        base.OnModelCreating(modelBuilder);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var entry in ChangeTracker.Entries<BaseEntity>()
                     .Where(q => q.State == EntityState.Added || q.State == EntityState.Modified))
        {

            entry.Entity.DateModified = DateTime.Now;
            if (entry.State == EntityState.Added)
            {
                entry.Entity.DateCreated = DateTime.Now;
            }
        }
        
        return base.SaveChangesAsync(cancellationToken);
    }
}