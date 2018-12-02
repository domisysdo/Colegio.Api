﻿using Abp.Domain.Entities.Auditing;
using Colegio.Enums;
using Colegio.Models.Inscripcion.InscripcionNs;
using System;
using System.Collections.Generic;

namespace Colegio.Models.Inscripcion.CuotaNs
{
    public class Cuota : FullAuditedEntity<int>
    {
        public int InscripcionId { get; set; }
        public virtual InscripcionNs.Inscripcion Inscripcion { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public decimal Monto { get; set; }
        public decimal MontoPago { get; set; }
        public decimal MontoMoraPago { get; set; }
        public Estado Estado { get; set; }
    }
}
