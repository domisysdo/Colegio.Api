using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Colegio.Enums;
using Colegio.Models.Nomina.ProfesorNs;
using Colegio.Nomina.ProfesorMateriaNs;
using System;
using System.Collections.Generic;

namespace Colegio.Nomina.ProfesorNs
{
    [AutoMap(typeof(Profesor))]
    public class ProfesorDto: EntityDto<int>
    {
        public string Identificador { get; set; }
        public string Nombres { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public Sexo Sexo { get; set; }
        public EstadoCivil EstadoCivil { get; set; }
        public Estado Estado { get; set; }
        public List<ProfesorMateriaDto> ListaMaterias { get; set; }
    }
}