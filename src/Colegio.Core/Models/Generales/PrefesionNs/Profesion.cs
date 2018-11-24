using Abp.Domain.Entities.Auditing;

namespace Colegio.Models.Generales.ProfesionNs
{
    public class Profesion : AuditedEntity<int>
    {
        public string Descripcion { get; set; }
    }
}
