using Abp.Domain.Entities.Auditing;
using Colegio.Models.Generales.TipoTelefonoNs;
using Colegio.Models.Inscripcion.EstudianteNs;

namespace Colegio.Models.Generales.TelefonoEstudianteNs
{
    public class TelefonoEstudiante : AuditedEntity<int>
    {
        public string Numero { get; set; }
        public int EstudianteId { get; set; }
        public virtual Estudiante Estudiante { get; set; }
        public int TipoTelefonoId { get; set; }
        public virtual TipoTelefono TipoTelefono { get; set; }
    }
}
