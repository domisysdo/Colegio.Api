using Abp.Domain.Entities.Auditing;
using Colegio.Models.Generales.TipoTelefonoNs;
using Colegio.Models.Inscripcion.GeneralNs.FamiliarEstudianteNs;

namespace Colegio.Models.Generales.TelefonoFamiliarNs
{
    public class TelefonoFamiliarEstudiante : AuditedEntity<int>
    {
        public string Numero { get; set; }
        public int TipoTelefonoId { get; set; }
        public virtual TipoTelefono TipoTelefono { get; set; }
        public int FamiliarEstudianteId { get; set; }
        public virtual FamiliarEstudiante FamiliarEstudiante { get; set; }
    }
}
