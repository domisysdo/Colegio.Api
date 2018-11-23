using Abp.Domain.Entities.Auditing;

namespace Colegio.Models.Generales.TipoTelefonoNs
{
    public class TipoTelefono : FullAuditedEntity<int>
    {
        public string Descripcion { get; set; }
    }
}
