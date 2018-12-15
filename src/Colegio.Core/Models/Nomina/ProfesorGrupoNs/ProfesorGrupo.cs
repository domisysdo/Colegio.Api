using Abp.Domain.Entities.Auditing;
using Colegio.Models.Inscripcion.GeneralNs.GrupoNs;
using Colegio.Models.Nomina.ProfesorNs;

namespace Colegio.Models.Nomina.ProfesorGrupoNs
{
    public class ProfesorGrupo: AuditedEntity<int>
    {
        public int ProfesorId { get; set; }
        public int GrupoId { get; set; }
        public virtual Grupo Grupo { get; set; }
        public virtual Profesor Profesor { get; set; }
    }
}
