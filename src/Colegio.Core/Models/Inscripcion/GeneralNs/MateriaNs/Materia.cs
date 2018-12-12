using Abp.Domain.Entities.Auditing;
using Colegio.Models.Notas.MetodoEvaluacionNs;

namespace Colegio.Models.Inscripcion.GeneralNs.MateriaNs
{
    public class Materia: AuditedEntity<int>
    {
        public string Identificador { get; set; }
        public string Nombre { get; set; }
        public decimal PrecioTotal { get; set; }
        public decimal PrecioInscripcion { get; set; }
        public int MetodoEvaluacionId { get; set; }
        public virtual MetodoEvaluacion MetodoEvaluacion { get; set; }
    }
}
