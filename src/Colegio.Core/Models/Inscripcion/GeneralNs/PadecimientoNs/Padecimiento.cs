using Abp.Domain.Entities.Auditing;
using Colegio.Models.Inscripcion.EstudianteNs;
using System;

namespace Colegio.Models.Inscripcion.GeneralNs.PadecimientoNs
{
    public class Padecimiento: AuditedEntity<int>
    {        
        public string Descripcion { get; set; }
        public string Nota { get; set; }
        public int EstudianteId { get; set; }
        public virtual Estudiante Estudiante { get; set; }
    }
}
