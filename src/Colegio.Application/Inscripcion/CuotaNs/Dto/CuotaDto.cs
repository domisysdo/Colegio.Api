using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Colegio.Enums;
using Colegio.Inscripcion.InscripcionNs;
using Colegio.Models.Inscripcion.CuotaNs;
using System;

namespace Colegio.Inscripcion.CuotaNs
{
    [AutoMap(typeof(Cuota))]
    public class CuotaDto: EntityDto<int>
    {
        public int InscripcionId { get; set; }
        public virtual InscripcionDto Inscripcion { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public decimal Monto { get; set; }
        public decimal MontoPago { get; set; }
        public decimal MontoMora { get; set; }
        public decimal MontoMoraPago { get; set; }
        public Estado Estado { get; set; }
    }
}