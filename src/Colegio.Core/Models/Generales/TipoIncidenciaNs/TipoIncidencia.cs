using Abp.Domain.Entities.Auditing;

namespace Colegio.Models.Generales.TipoIncidenciaNs
{
    public class TipoIncidencia : AuditedEntity<int>
    {
        public string Descripcion { get; set; }
    }
}
