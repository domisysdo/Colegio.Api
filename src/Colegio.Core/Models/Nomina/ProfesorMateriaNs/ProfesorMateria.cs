using Abp.Domain.Entities.Auditing;
using Colegio.Models.Inscripcion.GeneralNs.MateriaNs;
using Colegio.Models.Nomina.ProfesorNs;

namespace Colegio.Models.Nomina.ProfesorMateriaNs
{
    public class ProfesorMateria: AuditedEntity<int>
    {
        public int ProfesorMateriaId { get; set; }
        public int ProfesorId { get; set; }
        public int MateriaId { get; set; }
        public virtual Materia Materia { get; set; }
        public virtual Profesor Profesor { get; set; }
    }
}
