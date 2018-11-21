using Abp.Zero.EntityFrameworkCore;
using Colegio.Authorization.Roles;
using Colegio.Authorization.Users;
using Colegio.Models.EstudianteNs;
using Colegio.Models.Generales.PaisNs;
using Colegio.Models.Generales.ProvinciaNs;
using Colegio.MultiTenancy;
using Microsoft.EntityFrameworkCore;

namespace Colegio.EntityFrameworkCore
{
    public class ColegioDbContext : AbpZeroDbContext<Tenant, Role, User, ColegioDbContext>
    {
        public DbSet<Estudiante> Estudiante { get; set; }
        public DbSet<Pais> Pais { get; set; }
        public DbSet<Provincia> Provincia { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Provincia>()
                .HasOne(x => x.Pais)
                .WithMany(x => x.ListaProvincias)
                .HasForeignKey(x => x.PaisId);

            base.OnModelCreating(modelBuilder);
        }

        public ColegioDbContext(DbContextOptions<ColegioDbContext> options)
            : base(options)
        {
        }
    }
}
