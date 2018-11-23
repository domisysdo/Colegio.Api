using Abp.Zero.EntityFrameworkCore;
using Colegio.Authorization.Roles;
using Colegio.Authorization.Users;
using Colegio.Models.EstudianteNs;
using Colegio.Models.Generales.MunicipioNs;
using Colegio.Models.Generales.PaisNs;
using Colegio.Models.Generales.ProvinciaNs;
using Colegio.Models.Generales.TipoTelefonoNs;
using Colegio.MultiTenancy;
using Microsoft.EntityFrameworkCore;

namespace Colegio.EntityFrameworkCore
{
    public class ColegioDbContext : AbpZeroDbContext<Tenant, Role, User, ColegioDbContext>
    {
        public DbSet<Estudiante> Estudiante { get; set; }
        public DbSet<Pais> Pais { get; set; }
        public DbSet<Provincia> Provincia { get; set; }
        public DbSet<Municipio> Municipio { get; set; }
        public DbSet<Sector> Sector { get; set; }
        public DbSet<TipoTelefono> TipoTelefono { get; set; }
        public DbSet<TipoDireccion> TipoDireccion { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Provincia>()
                .HasOne(x => x.Pais)
                .WithMany(x => x.ListaProvincias)
                .HasForeignKey(x => x.PaisId);

            modelBuilder.Entity<Municipio>()
                .HasOne(x => x.Provincia)
                .WithMany(x => x.ListaMunicipios)
                .HasForeignKey(x => x.ProvinciaId);

            modelBuilder.Entity<Sector>()
                .HasOne(x => x.Municipio)
                .WithMany(x => x.ListaSectores)
                .HasForeignKey(x => x.MunicipioId);

            base.OnModelCreating(modelBuilder);
        }

        public ColegioDbContext(DbContextOptions<ColegioDbContext> options)
            : base(options)
        {
        }
    }
}
