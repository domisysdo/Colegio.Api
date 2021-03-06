﻿using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Colegio.Enums;
using Colegio.Generales.DireccionFamiliarEstudianteNs;
using Colegio.Generales.EmailFamiliarEstudianteNs;
using Colegio.Generales.TelefonoFamiliarEstudianteNs;
using Colegio.Models.Inscripcion.GeneralNs.FamiliarEstudianteNs;
using System.Collections.Generic;
using System;
using Colegio.Models.Inscripcion.EstudianteNs;

namespace Colegio.Inscripcion.FamiliarEstudianteNs
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
        public int NacionalidadId { get; set; }
        public int ParentescoId { get; set; }
        public int ProfesionId { get; set; }
        public string NumeroIdentificacion { get; set; }
        public int TipoIdentificacionId { get; set; }
        public string ParentescoNombre { get; set; }
        public string NombreCompleto { get; set; }
        public int EstudianteId { get; set; }
    }
}