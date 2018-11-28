using Abp.Domain.Entities.Auditing;
using Colegio.Models.Inscripcion.GeneralNs.MateriaNs;

namespace Colegio.Models.Inscripcion.GeneralNs.GrupoNs
{
    public class Grupo: AuditedEntity<int>
    {
        public string Identificador { get; set; }
        public int MateriaId { get; set; }
        public virtual Materia Materia { get; set; }
    }
}
