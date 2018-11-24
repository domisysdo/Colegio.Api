using Abp.Domain.Entities.Auditing;
using Colegio.Models.Generales.TipoEmailNs;
using Colegio.Models.Inscripcion.EstudianteNs;

namespace Colegio.Models.Generales.EmailEstudianteNs
{
    public class EmailEstudiante : AuditedEntity<int>
    {
        public string Email { get; set; }
        public int EstudianteId { get; set; }
        public virtual Estudiante Estudiante { get; set; }
        public int TipoEmailId { get; set; }
        public virtual TipoEmail TipoEmail { get; set; }
    }
}
