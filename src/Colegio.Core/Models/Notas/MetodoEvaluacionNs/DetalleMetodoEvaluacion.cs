using Abp.Domain.Entities.Auditing;

namespace Colegio.Models.Notas.MetodoEvaluacionNs
{
    public class DetalleMetodoEvaluacion: AuditedEntity<int>
    {
        public int MetodoEvaluacionId { get; set; }
        public string Descripcion { get; set; }
        public double Puntuacion { get; set; }
        public virtual MetodoEvaluacion MetodoEvaluacion { get; set; }
    }
}
