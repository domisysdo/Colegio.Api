using Abp.Zero.EntityFrameworkCore;
using Colegio.Authorization.Roles;
using Colegio.Authorization.Users;
using Colegio.Models.Generales.DireccionEstudianteNs;
using Colegio.Models.Generales.DireccionFamiliarEstudianteNs;
using Colegio.Models.Generales.EmailEstudianteNs;
using Colegio.Models.Generales.EmailFamiliarEstudianteNs;
using Colegio.Models.Generales.IncidenciaEstudianteNs;
using Colegio.Models.Generales.LugarTrabajoNs;
using Colegio.Models.Generales.MunicipioNs;
using Colegio.Models.Generales.NacionalidadNs;
using Colegio.Models.Generales.PaisNs;
using Colegio.Models.Generales.ProfesionNs;
using Colegio.Models.Generales.ProvinciaNs;
using Colegio.Models.Generales.SectorNs;
using Colegio.Models.Generales.TelefonoEstudianteNs;
using Colegio.Models.Generales.TelefonoFamiliarNs;
using Colegio.Models.Generales.TipoDireccionNs;
using Colegio.Models.Generales.TipoEmailNs;
using Colegio.Models.Generales.TipoIdentificacionNs;
using Colegio.Models.Generales.TipoIncidenciaNs;
using Colegio.Models.Generales.TipoTelefonoNs;
using Colegio.Models.Inscripcion.EstudianteNs;
using Colegio.Models.Inscripcion.GeneralNs.FamiliarEstudianteNs;
using Colegio.Models.Inscripcion.GeneralNs.PadecimientoNs;
using Colegio.Models.Inscripcion.GeneralNs.ParentescoNs;
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
        public DbSet<LugarTrabajo> LugarTrabajo { get; set; }
        public DbSet<FamiliarEstudiante> FamiliarEstudiante { get; set; }
        public DbSet<Profesion> Profesion { get; set; }
        public DbSet<TipoIdentificacion> TipoIdentificacion { get; set; }
        public DbSet<TelefonoEstudiante> TelefonoEstudiante { get; set; }
        public DbSet<TelefonoFamiliarEstudiante> TelefonoFamiliarEstudiante { get; set; }
        public DbSet<EmailEstudiante> EmailEstudiante { get; set; }
        public DbSet<EmailFamiliarEstudiante> EmailFamiliarEstudiantes { get; set; }
        public DbSet<Padecimiento> Padecimiento { get; set; }
        public DbSet<TipoEmail> TipoEmail { get; set; }
        public DbSet<Parentesco> Parentesco { get; set; }
        public DbSet<DireccionEstudiante> DireccionEstudiante { get; set; }
        public DbSet<DireccionFamiliarEstudiante> DireccionFamiliarEstudiante { get; set; }
        public DbSet<IncidenciaEstudiante> IncidenciaEstudiante { get; set; }
        public DbSet<TipoIncidencia> TipoIncidencia { get; set; }
        public DbSet<Nacionalidad> Nacionalidad { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Relaciones

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

            modelBuilder.Entity<TelefonoEstudiante>()
                .HasOne(x => x.TipoTelefono)
                .WithMany()
                .HasForeignKey(x => x.TipoTelefonoId);

            modelBuilder.Entity<EmailEstudiante>()
                .HasOne(x => x.TipoEmail)
                .WithMany()
                .HasForeignKey(x => x.TipoEmailId);

            modelBuilder.Entity<LugarTrabajo>()
                .HasOne(x => x.Sector)
                .WithMany()
                .HasForeignKey(x => x.SectorId);

            modelBuilder.Entity<FamiliarEstudiante>()
                .HasOne(x => x.LugarTrabajo)
                .WithMany()
                .HasForeignKey(x => x.LugarTrabajoId);

            modelBuilder.Entity<FamiliarEstudiante>()
                .HasOne(x => x.Profesion)
                .WithMany()
                .HasForeignKey(x => x.ProfesionId);

            modelBuilder.Entity<FamiliarEstudiante>()
                .HasOne(x => x.TipoIdentificacion)
                .WithMany()
                .HasForeignKey(x => x.TipoIdentificacionId);

            modelBuilder.Entity<TelefonoFamiliarEstudiante>()
                .HasOne(x => x.FamiliarEstudiante)
                .WithMany(x => x.ListaTelefonos)
                .HasForeignKey(x => x.FamiliarEstudianteId);

            modelBuilder.Entity<TelefonoEstudiante>()
                .HasOne(x => x.Estudiante)
                .WithMany(x => x.ListaTelefonos)
                .HasForeignKey(x => x.EstudianteId);

            modelBuilder.Entity<EmailEstudiante>()
                .HasOne(x => x.Estudiante)
                .WithMany(x => x.ListaEmail)
                .HasForeignKey(x => x.EstudianteId);

            modelBuilder.Entity<Estudiante>()
                .HasOne(x => x.Nacionalidad)
                .WithMany()
                .HasForeignKey(x => x.NacionalidadId);

            modelBuilder.Entity<Padecimiento>()
                .HasOne(x => x.Estudiante)
                .WithMany(x => x.ListaPadecimientos)
                .HasForeignKey(x => x.EstudianteId);

            modelBuilder.Entity<DireccionEstudiante>()
                .HasOne(x => x.Estudiante)
                .WithMany(x => x.ListaDireccionEstudiante)
                .HasForeignKey(x => x.EstudianteId);

            modelBuilder.Entity<DireccionEstudiante>()
                .HasOne(x => x.Pais)
                .WithMany()
                .HasForeignKey(x => x.PaisId);

            modelBuilder.Entity<DireccionEstudiante>()
                .HasOne(x => x.Provincia)
                .WithMany()
                .HasForeignKey(x => x.ProvinciaId);

            modelBuilder.Entity<DireccionEstudiante>()
                .HasOne(x => x.Municipio)
                .WithMany()
                .HasForeignKey(x => x.MunicipioId);

            modelBuilder.Entity<DireccionEstudiante>()
                .HasOne(x => x.Sector)
                .WithMany()
                .HasForeignKey(x => x.SectorId);

            modelBuilder.Entity<DireccionFamiliarEstudiante>()
                .HasOne(x => x.FamiliarEstudiante)
                .WithMany(x => x.ListaDireccion)
                .HasForeignKey(x => x.FamiliarEstudianteId);

            modelBuilder.Entity<DireccionFamiliarEstudiante>()
                .HasOne(x => x.Pais)
                .WithMany()
                .HasForeignKey(x => x.PaisId);

            modelBuilder.Entity<DireccionFamiliarEstudiante>()
                .HasOne(x => x.Provincia)
                .WithMany()
                .HasForeignKey(x => x.ProvinciaId);

            modelBuilder.Entity<DireccionFamiliarEstudiante>()
                .HasOne(x => x.Municipio)
                .WithMany()
                .HasForeignKey(x => x.MunicipioId);

            modelBuilder.Entity<DireccionFamiliarEstudiante>()
                .HasOne(x => x.Sector)
                .WithMany()
                .HasForeignKey(x => x.SectorId);
            #endregion

            base.OnModelCreating(modelBuilder);
        }

        public ColegioDbContext(DbContextOptions<ColegioDbContext> options)
            : base(options)
        {
        }
    }
}
