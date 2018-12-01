using Abp.Domain.Entities.Auditing;

namespace Colegio.Models.Generales.TipoPadecimientoNs
{
    public class TipoPadecimiento : AuditedEntity<int>
    {
        public string Descripcion { get; set; }
    }
}
