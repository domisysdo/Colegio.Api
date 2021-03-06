﻿using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Colegio.Models.Generales.DireccionEstudianteNs;

namespace Colegio.Generales.DireccionEstudianteNs
{
    [AutoMap(typeof(DireccionEstudiante))]
    public class DireccionEstudianteDto: EntityDto<int>
    {
        public string Descripcion { get; set; }
        public int EstudianteId { get; set; }
        public int TipoDireccionId { get; set; }
        public int SectorId { get; set; }

        public string SectorNombre { get; set; }
        public string TipoDireccionNombre { get; set; }

    }
}