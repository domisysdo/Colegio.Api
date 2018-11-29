using Abp.Domain.Entities.Auditing;
using Colegio.Models.Inscripcion.GeneralNs.CostoInscripcionNs;
using Colegio.Models.Inscripcion.GeneralNs.GrupoNs;

namespace Colegio.Models.Inscripcion.GeneralNs.CostoInscripcionNs
{
    public class CostoInscripcion : AuditedEntity<int>
    {
        public int GrupoId { get; set; }
        public decimal Costoinscripcion { get; set; }
        public decimal Costomensualidad { get; set; }
        public virtual Grupo Grupo { get; set; }
    }
}
