using Abp.Domain.Entities.Auditing;
using Colegio.Models.Generales.ProvinciaNs;

namespace Colegio.Models.Generales.MunicipioNs
{
    public class Municipio:  FullAuditedEntity<int>
    {
        public string Identificador { get; set; }
        public string Nombre { get; set; }
        public int ProvinciaId { get; set; }
        public virtual Provincia Provincia { get; set; }
    }
}
