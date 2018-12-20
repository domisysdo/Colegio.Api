using Abp.Domain.Entities.Auditing;
using Colegio.Enums;
using Colegio.Models.Inscripcion.PagoNs;
using Colegio.Models.Inscripcion.CuotaNs;
using System;
using System.Collections.Generic;

namespace Colegio.Models.Inscripcion.PagoDetalleNs
{
    public class PagoDetalle : FullAuditedEntity<int>
    {
        public int PagoId { get; set; }
        public virtual Pago Pago { get; set; }
        public int CuotaId { get; set; }
        public virtual Cuota Cuota { get; set; }
        public virtual decimal MontoPago { get; set; }
        public virtual decimal MontoMoraPago { get; set; }

    }
}
