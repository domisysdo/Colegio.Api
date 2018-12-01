using Abp.Zero.EntityFrameworkCore;
using Colegio.Authorization.Roles;
using Colegio.Authorization.Users;
using Colegio.Models.Generales.DireccionEstudianteNs;
using Colegio.Models.Generales.DireccionFamiliarEstudianteNs;
using Colegio.Models.Generales.EmailEstudianteNs;
using Colegio.Models.Generales.EmailFamiliarEstudianteNs;
using Colegio.Models.Generales.IncidenciaEstudianteNs;
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
using Colegio.Models.Generales.TipoPadecimientoNs;
using Colegio.Models.Inscripcion.EstudianteNs;
using Colegio.Models.Inscripcion.GeneralNs.FamiliarEstudianteNs;
using Colegio.Models.Inscripcion.GeneralNs.GrupoNs;
using Colegio.Models.Inscripcion.GeneralNs.MateriaNs;
using Colegio.Models.Inscripcion.GeneralNs.PadecimientoNs;
using Colegio.Models.Inscripcion.GeneralNs.ParentescoNs;
using Colegio.Models.Nomina.ProfesorNs;
using Colegio.MultiTenancy;
using Microsoft.EntityFrameworkCore;
using Colegio.Models.Inscripcion.GeneralNs.PeriodoNs;

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
        public DbSet<FamiliarEstudiante> FamiliarEstudiante { get; set; }
        public DbSet<Profesion> Profesion { get; set; }
        public DbSet<TipoIdentificacion> TipoIdentificacion { get; set; }
        public DbSet<TelefonoEstudiante> TelefonoEstudiante { get; set; }
        public DbSet<TelefonoFamiliarEstudiante> TelefonoFamiliarEstudiante { get; set; }
        public DbSet<EmailEstudiante> EmailEstudiante { get; set; }
        public DbSet<EmailFamiliarEstudiante> EmailFamiliarEstudiante { get; set; }
        public DbSet<Padecimiento> Padecimiento { get; set; }
        public DbSet<TipoEmail> TipoEmail { get; set; }
        public DbSet<Parentesco> Parentesco { get; set; }
        public DbSet<DireccionEstudiante> DireccionEstudiante { get; set; }
        public DbSet<DireccionFamiliarEstudiante> DireccionFamiliarEstudiante { get; set; }
        public DbSet<IncidenciaEstudiante> IncidenciaEstudiante { get; set; }
        public DbSet<TipoIncidencia> TipoIncidencia { get; set; }
        public DbSet<Nacionalidad> Nacionalidad { get; set; }
        public DbSet<Grupo> Grupo { get; set; }
        public DbSet<Materia> Materia { get; set; }
        public DbSet<TipoPadecimiento> TipoPadecimiento { get; set; }
        public DbSet<Profesor> Profesor { get; set; }
        public DbSet<Periodo> Periodo { get; set; }


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

            modelBuilder.Entity<FamiliarEstudiante>()
                .HasOne(x => x.Profesion)
                .WithMany()
                .HasForeignKey(x => x.ProfesionId);

            modelBuilder.Entity<FamiliarEstudiante>()
                .HasOne(x => x.TipoIdentificacion)
                .WithMany()
                .HasForeignKey(x => x.TipoIdentificacionId);

            modelBuilder.Entity<FamiliarEstudiante>()
                .HasOne(x => x.Parentesco)
                .WithMany()
                .HasForeignKey(x => x.ParentescoId);

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
                .HasOne(x => x.Sector)
                .WithMany()
                .HasForeignKey(x => x.SectorId);

            modelBuilder.Entity<DireccionFamiliarEstudiante>()
                .HasOne(x => x.FamiliarEstudiante)
                .WithMany(x => x.ListaDirecciones)
                .HasForeignKey(x => x.FamiliarEstudianteId);

            modelBuilder.Entity<DireccionFamiliarEstudiante>()
                .HasOne(x => x.Sector)
                .WithMany()
                .HasForeignKey(x => x.SectorId);

            modelBuilder.Entity<Grupo>()
                .HasOne(x => x.Materia)
                .WithMany()
                .HasForeignKey(x => x.MateriaId);
            #endregion

            base.OnModelCreating(modelBuilder);
        }

        public ColegioDbContext(DbContextOptions<ColegioDbContext> options)
            : base(options)
        {
        }
    }
}
