﻿using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Colegio.Inscripcion.GrupoNs;
using Colegio.Models.Inscripcion.InscripcionNs;
using Colegio.Inscripcion.EstudianteNs;
using Colegio.Inscripcion.PeriodoNs;

namespace Colegio.Inscripcion.InscripcionNs
{
    [AutoMap(typeof(Models.Inscripcion.InscripcionNs.Inscripcion))]
    public class InscripcionDto: EntityDto<int>
    {
        public int EstudianteId { get; set; }
        public virtual EstudianteDto Estudiante { get; set; }
        public int GrupoId { get; set; }
        public virtual GrupoDto Grupo { get; set; }
        public int PeriodoId { get; set; }
        public virtual PeriodoDto Periodo { get; set; }
    }
}