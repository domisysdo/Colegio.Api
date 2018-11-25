using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Colegio.Models.Generales.IncidenciaEstudianteNs;
using System;

namespace Colegio.Generales.IncidenciaEstudianteNs
{
    [AutoMap(typeof(IncidenciaEstudiante))]
    public class IncidenciaEstudianteDto: EntityDto<int>
    {
        public bool Justificada { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }
        public int MateriaId { get; set; }
        public int EstudianteId { get; set; }
        public int TipoIncidenciaId { get; set; }
    }
}