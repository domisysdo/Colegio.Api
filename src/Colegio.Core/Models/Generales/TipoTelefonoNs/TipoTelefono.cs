using Abp.Domain.Entities.Auditing;

namespace Colegio.Models.Generales.TipoTelefonoNs
{
    public class TipoTelefono : AuditedEntity<int>
    {
        public string Descripcion { get; set; }
    }
}
