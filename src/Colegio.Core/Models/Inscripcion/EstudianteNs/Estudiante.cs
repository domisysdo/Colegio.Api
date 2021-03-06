﻿using Abp.Domain.Entities.Auditing;
using Colegio.Enums;
using Colegio.Models.Generales.DireccionEstudianteNs;
using Colegio.Models.Generales.EmailEstudianteNs;
using Colegio.Models.Generales.NacionalidadNs;
using Colegio.Models.Generales.TelefonoEstudianteNs;
using Colegio.Models.Inscripcion.GeneralNs.FamiliarEstudianteNs;
using Colegio.Models.Inscripcion.GeneralNs.PadecimientoNs;
using System;
using System.Collections.Generic;

namespace Colegio.Models.Inscripcion.EstudianteNs
{
    public class Estudiante : FullAuditedEntity<int>
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
        public double SecuenciaIdentificador { get; set; }
        public virtual Nacionalidad Nacionalidad { get; set; }
        public virtual List<TelefonoEstudiante> ListaTelefonos { get; set; }
        public virtual List<Padecimiento> ListaPadecimientos { get; set; }
        public virtual List<EmailEstudiante> ListaEmail { get; set; }
        public virtual List<DireccionEstudiante> ListaDireccionEstudiante { get; set; }
        public virtual List<FamiliarEstudiante> ListaFamiliarEstudiante { get; set; }

    }
}
