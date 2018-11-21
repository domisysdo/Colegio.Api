using Abp.Domain.Entities.Auditing;
using Colegio.Models.Generales.ProvinciaNs;
using System.Collections.Generic;

namespace Colegio.Models.Generales.PaisNs
{
    public class Pais :  FullAuditedEntity<int>
    {
        public string Identificador { get; set; }
        public string Nombre { get; set; }
        public virtual IEnumerable<Provincia> ListaProvincias { get; set; }
    }
}
