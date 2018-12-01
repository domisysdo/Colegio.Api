using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Colegio.Enums;
using Colegio.Generales.DireccionEstudianteNs;
using Colegio.Generales.EmailEstudianteNs;
using Colegio.Generales.TelefonoEstudianteNs;
using Colegio.Incripcion.FamiliarEstudianteNs;
using Colegio.Incripcion.PadecimientoNs;
using Colegio.Models.Inscripcion.EstudianteNs;
using System;
using System.Collections.Generic;

namespace Colegio.Incripcion.EstudianteNs
{
    [AutoMap(typeof(Estudiante))]
    public class EstudianteDto: EntityDto<int>
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
        public List<TelefonoEstudianteDto> ListaTelefonos { get; set; }
        public List<PadecimientoDto> ListaPadecimientos { get; set; }
        public List<EmailEstudianteDto> ListaEmail { get; set; }
        public List<DireccionEstudianteDto> ListaDireccionEstudiante { get; set; }
        public virtual List<FamiliarEstudianteDto> ListaFamiliarEstudiante { get; set; }

    }
}