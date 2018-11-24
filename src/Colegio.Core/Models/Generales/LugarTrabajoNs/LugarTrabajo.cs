using Abp.Domain.Entities.Auditing;
using Colegio.Models.Generales.MunicipioNs;
using Colegio.Models.Generales.SectorNs;

namespace Colegio.Models.Generales.LugarTrabajoNs
{
    public class LugarTrabajo : AuditedEntity<int>
    {
        public string Descripcion { get; set; }    
        public int SectorId { get; set; }
        public virtual Sector Sector { get; set; }
    }
}
