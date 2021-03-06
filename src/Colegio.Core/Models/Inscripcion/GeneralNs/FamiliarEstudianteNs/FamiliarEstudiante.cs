﻿using Abp.Domain.Entities.Auditing;
using Colegio.Enums;
using Colegio.Models.Generales.DireccionFamiliarEstudianteNs;
using Colegio.Models.Generales.EmailFamiliarEstudianteNs;
using Colegio.Models.Generales.NacionalidadNs;
using Colegio.Models.Generales.ProfesionNs;
using Colegio.Models.Generales.TelefonoFamiliarNs;
using Colegio.Models.Generales.TipoIdentificacionNs;
using Colegio.Models.Inscripcion.EstudianteNs;
using Colegio.Models.Inscripcion.GeneralNs.ParentescoNs;
using System;
using System.Collections.Generic;

namespace Colegio.Models.Inscripcion.GeneralNs.FamiliarEstudianteNs
{
    public class FamiliarEstudiante: FullAuditedEntity<int>
    {
        public string Nombres { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string NumeroIdentificacion { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int ParentescoId { get; set; }
        public virtual Parentesco Parentesco { get; set; }
        public int ProfesionId { get; set; }
        public Sexo Sexo { get; set; }
        public EstadoCivil EstadoCivil { get; set; }
        public virtual Profesion Profesion { get; set; }
        public int NacionalidadId { get; set; }
        public virtual Nacionalidad Nacionalidad { get; set; }
        public int TipoIdentificacionId { get; set; }
        public int EstudianteId { get; set; }
        public Estudiante Estudiante { get; set; }
        public virtual TipoIdentificacion TipoIdentificacion { get; set; }    
    }
}
