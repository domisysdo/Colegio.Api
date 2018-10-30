using Abp.Domain.Entities.Auditing;
using Colegio.Enums;

namespace Colegio.Models.Estudiante
{
    public class Estudiante : FullAuditedEntity
    {
        public string Nombres { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public Estado Estado { get; set; }
    }
}
