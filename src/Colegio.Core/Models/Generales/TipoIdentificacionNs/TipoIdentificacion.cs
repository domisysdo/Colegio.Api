using Abp.Domain.Entities.Auditing;

namespace Colegio.Models.Generales.TipoIdentificacionNs
{
    public class TipoIdentificacion : AuditedEntity<int>
    {
        public string Descripcion { get; set; }
    }
}
