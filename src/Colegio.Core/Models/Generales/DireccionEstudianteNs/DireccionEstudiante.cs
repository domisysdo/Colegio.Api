using Abp.Domain.Entities.Auditing;
using Colegio.Models.Generales.SectorNs;
using Colegio.Models.Generales.TipoDireccionNs;
using Colegio.Models.Inscripcion.EstudianteNs;

namespace Colegio.Models.Generales.DireccionEstudianteNs
{
    public class DireccionEstudiante : AuditedEntity<int>
    {
        public string Descripcion { get; set; }
        public int EstudianteId { get; set; }
        public virtual Estudiante Estudiante { get; set; }
        public int TipoDireccionId { get; set; }
        public virtual TipoDireccion TipoDireccion { get; set; }
        public int SectorId { get; set; }
        public virtual Sector Sector { get; set; }
    }
}
