using Abp.Domain.Entities.Auditing;
using Colegio.Models.Generales.EstadoIncidenciaNs;
using System.Collections.Generic;

namespace Colegio.Models.Generales.TipoIncidenciaNs
{
    public class TipoIncidencia : AuditedEntity<int>
    {
        public string Descripcion { get; set; }
        public List<EstadoIncidencia> ListaEstadoIncidencia { get; set; }
    }
}
