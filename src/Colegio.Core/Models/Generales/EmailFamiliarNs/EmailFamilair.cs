using Abp.Domain.Entities.Auditing;
using Colegio.Models.Generales.TipoEmailNs;
using Colegio.Models.Inscripcion.GeneralNs.FamiliarEstudianteNs;

namespace Colegio.Models.Generales.EmailFamiliarEstudianteNs
{
    public class EmailFamiliarEstudiante : AuditedEntity<int>
    {
        public string Email { get; set; }
        public int FamiliarEstudianteId { get; set; }
        public virtual FamiliarEstudiante FamiliarEstudiante { get; set; }
        public int TipoEmailId { get; set; }
        public virtual TipoEmail TipoEmail { get; set; }
    }
}
