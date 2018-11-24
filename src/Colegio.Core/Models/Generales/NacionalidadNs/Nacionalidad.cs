using Abp.Domain.Entities.Auditing;

namespace Colegio.Models.Generales.NacionalidadNs
{
    public class Nacionalidad : AuditedEntity<int>
    {
        public string Identificador { get; set; }
        public string Descripcion { get; set; }
    }
}
