using Abp.Domain.Entities.Auditing;

namespace Colegio.Models.Generales.EstadoIncidenciaNs
{
    public class EstadoIncidencia : AuditedEntity<int>
    {
        public string Descripcion { get; set; }
        public int TipoIncidenciaId { get; set; }
    }
}
