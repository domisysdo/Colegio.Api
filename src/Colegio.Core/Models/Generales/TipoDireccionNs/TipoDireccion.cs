using Abp.Domain.Entities.Auditing;

namespace Colegio.Models.Generales.TipoDireccionNs
{
    public class TipoDireccion : AuditedEntity<int>
    {
        public string Descripcion { get; set; }
    }
}
