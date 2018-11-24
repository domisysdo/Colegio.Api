using Abp.Domain.Entities.Auditing;
using Colegio.Models.Generales.MunicipioNs;

namespace Colegio.Models.Generales.SectorNs
{
    public class Sector:  AuditedEntity<int>
    {
        public string Identificador { get; set; }
        public string Nombre { get; set; }
        public int MunicipioId { get; set; }
        public virtual Municipio Municipio { get; set; }
    }
}
