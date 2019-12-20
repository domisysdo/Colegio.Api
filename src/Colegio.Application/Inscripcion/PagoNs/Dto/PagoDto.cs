using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using Colegio.Inscripcion.InscripcionNs;
using Colegio.Inscripcion.PagoDetalleNs;
using System.Collections.Generic;

namespace Colegio.Inscripcion.PagoNs
{
    [AutoMap(typeof(Models.Inscripcion.PagoNs.Pago))]
    public class PagoDto: EntityDto<int>
    {
        public int InscripcionId { get; set; }
        public virtual InscripcionDto Inscripcion { get; set; }
        public DateTime Fecha { get; set; }
        public virtual List<PagoDetalleDto> PagoDetalle { get; set; }
    }
}