using Abp.Domain.Entities.Auditing;

namespace Colegio.Models.Generales.TipoEmailNs
{
    public class TipoEmail : AuditedEntity<int>
    {
        public string Descripcion { get; set; }
    }
}
