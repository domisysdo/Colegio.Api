using Abp.Domain.Entities.Auditing;

namespace Colegio.Models.Inscripcion.GeneralNs.ParentescoNs
{
    public class Parentesco: AuditedEntity<int>
    {
        public string Descripcion { get; set; }
    }
}
