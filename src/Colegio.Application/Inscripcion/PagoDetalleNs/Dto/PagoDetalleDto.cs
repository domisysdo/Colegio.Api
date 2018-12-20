using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using Colegio.Inscripcion.InscripcionNs;
using Colegio.Inscripcion.CuotaNs;
using Colegio.Inscripcion.PagoNs;

namespace Colegio.Inscripcion.PagoDetalleNs
{
    [AutoMap(typeof(Models.Inscripcion.PagoDetalleNs.PagoDetalle))]
    public class PagoDetalleDto: EntityDto<int>
    {
        public int PagoId { get; set; }
        public virtual PagoDto Pago { get; set; }
        public int CuotaId { get; set; }
        public virtual CuotaDto Cuota { get; set; }
        public virtual decimal MontoPago { get; set; }
        public virtual decimal MontoMoraPago { get; set; }
    }
}