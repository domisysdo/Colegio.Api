using Abp.Domain.Entities.Auditing;
using Colegio.Enums;
using Colegio.Models.Inscripcion.PagoDetalleNs;
using System;
using System.Collections.Generic;

namespace Colegio.Models.Inscripcion.PagoNs
{
    public class Pago : FullAuditedEntity<int>
    {
        public int InscripcionId { get; set; }
        public virtual Models.Inscripcion.InscripcionNs.Inscripcion Inscripcion { get; set; }
        public DateTime Fecha { get; set; }
        public virtual List<PagoDetalle> PagoDetalle { get; set; }

    }
}
