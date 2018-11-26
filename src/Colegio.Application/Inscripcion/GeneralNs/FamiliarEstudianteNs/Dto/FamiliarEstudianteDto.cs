using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Colegio.Enums;
using Colegio.Models.Inscripcion.GeneralNs.FamiliarEstudianteNs;
using System;

namespace Colegio.Incripcion.FamiliarEstudianteNs
{
    [AutoMap(typeof(FamiliarEstudiante))]
    public class FamiliarEstudianteDto: EntityDto<int>
    {
        public string Identificador { get; set; }
        public string Nombres { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public Sexo Sexo { get; set; }
        public EstadoCivil EstadoCivil { get; set; }
        public Estado Estado { get; set; }
        public int NacionalidadId { get; set; }
    }
}