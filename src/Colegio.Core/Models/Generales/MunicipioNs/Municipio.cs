using Abp.Domain.Entities.Auditing;
using Colegio.Models.Generales.ProvinciaNs;
using Colegio.Models.Generales.SectorNs;
using System.Collections.Generic;

namespace Colegio.Models.Generales.MunicipioNs
{
    public class Municipio: AuditedEntity<int>
    {
        public string Identificador { get; set; }
        public string Nombre { get; set; }
        public int ProvinciaId { get; set; }
        public virtual Provincia Provincia { get; set; }
        public virtual IEnumerable<Sector> ListaSectores { get; set; }

    }
}
