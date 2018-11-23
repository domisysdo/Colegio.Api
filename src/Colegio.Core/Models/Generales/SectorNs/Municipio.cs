using Abp.Domain.Entities.Auditing;
using Colegio.Models.Generales.ProvinciaNs;

namespace Colegio.Models.Generales.MunicipioNs
{
    public class Sector:  FullAuditedEntity<int>
    {
        public string Identificador { get; set; }
        public string Nombre { get; set; }
        public int MunicipioId { get; set; }
        public virtual Municipio Municipio { get; set; }
    }
}
