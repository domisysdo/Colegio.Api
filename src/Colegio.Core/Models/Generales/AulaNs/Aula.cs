using Abp.Domain.Entities.Auditing; 

namespace Colegio.Models.Generales.AulaNs
{
    public class Aula:  AuditedEntity<int>
    {
        public string Identificador { get; set; }
        public string Descripcion { get; set; }
        public string Ubicacion { get; set; } 
    }
}
