using Abp.Domain.Entities.Auditing;
using Colegio.Models.Generales.MunicipioNs;
using Colegio.Models.Generales.PaisNs;
using Colegio.Models.Generales.ProvinciaNs;
using Colegio.Models.Generales.SectorNs;
using Colegio.Models.Generales.TipoDireccionNs;
using Colegio.Models.Inscripcion.EstudianteNs;
using Colegio.Models.Inscripcion.GeneralNs.FamiliarEstudianteNs;

namespace Colegio.Models.Generales.DireccionFamiliarEstudianteNs
{
    public class DireccionFamiliarEstudiante : AuditedEntity<int>
    {
        public string Descripcion { get; set; }
        public int FamiliarEstudianteId { get; set; }
        public virtual FamiliarEstudiante FamiliarEstudiante { get; set; }
        public int TipoDireccionId { get; set; }
        public virtual TipoDireccion TipoDireccion { get; set; }
        public int PaisId { get; set; }
        public virtual Pais Pais { get; set; }
        public int ProvinciaId { get; set; }
        public virtual Provincia Provincia { get; set; }
        public int MunicipioId { get; set; }
        public virtual Municipio Municipio { get; set; }
        public int SectorId { get; set; }
        public virtual Sector Sector { get; set; }
    }
}
