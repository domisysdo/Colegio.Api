using Abp.Domain.Entities.Auditing;

namespace Colegio.Models.Inscripcion.GeneralNs.MateriaNs
{
    public class Materia: AuditedEntity<int>
    {
        public string Identificador { get; set; }
        public string Nombre { get; set; }
        public decimal PrecioTotal { get; set; }
        public decimal PrecioInscripcion { get; set; }
    }
}
