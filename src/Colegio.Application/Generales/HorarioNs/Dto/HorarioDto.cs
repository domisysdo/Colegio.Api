using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Colegio.Enums;
using Colegio.Models.Generales.HorarioNs;
using System;

namespace Colegio.Generales.HorarioNs.Dto
{
    [AutoMap(typeof(Horario))]
    public class HorarioDto : EntityDto<int>
    {
        public DiaSemanaEnum Dia { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFin { get; set; }
        public string AulaIdentificador { get; set; }
        public int GrupoId { get; set; }
        public int AulaId { get; set; }

    }
}
