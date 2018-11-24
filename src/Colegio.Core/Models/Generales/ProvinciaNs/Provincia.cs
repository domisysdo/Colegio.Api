using Abp.Domain.Entities.Auditing;
using Colegio.Models.Generales.MunicipioNs;
using Colegio.Models.Generales.PaisNs;
using System.Collections.Generic;

namespace Colegio.Models.Generales.ProvinciaNs
{
    public class Provincia:  AuditedEntity<int>
    {
        public string Identificador { get; set; }
        public string Nombre { get; set; }
        public int PaisId { get; set; }
        public virtual Pais Pais { get; set; }
        public virtual IEnumerable<Municipio> ListaMunicipios { get; set; }

    }
}
