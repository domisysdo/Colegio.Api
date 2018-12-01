using Abp.Domain.Entities.Auditing;
using Colegio.Enums;
using System;

namespace Colegio.Models.Inscripcion.GeneralNs.PeriodoNs
{
    public class Periodo: AuditedEntity<int>
    {
        public string Identificador { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public Estado Estado { get; set; }
    }
}
