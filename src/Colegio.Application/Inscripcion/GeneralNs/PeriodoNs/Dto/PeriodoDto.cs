using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Colegio.Enums;
using Colegio.Models.Inscripcion.GeneralNs.PeriodoNs;
using System;

namespace Colegio.Incripcion.PeriodoNs
{
    [AutoMap(typeof(Periodo))]
    public class PeriodoDto: EntityDto<int>
    {
        public string Identificador { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public Estado Estado { get; set; }
    }
}