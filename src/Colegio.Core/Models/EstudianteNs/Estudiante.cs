
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Colegio.Enums;

namespace Colegio.Models.EstudianteNs
{
    public class Estudiante :  FullAuditedEntity<int>
    {
        public string Nombres { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public Estado Estado { get; set; }
    }
}
