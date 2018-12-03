using Abp.Domain.Entities.Auditing;
using Colegio.Enums;
using System;
using System.Collections.Generic;

namespace Colegio.Models.Nomina.ProfesorNs
{
    public class Profesor:  AuditedEntity<int>
    {
        public string Identificador { get; set; }
        public string Nombres { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public Sexo Sexo { get; set; }
        public EstadoCivil EstadoCivil { get; set; }
        public Estado Estado { get; set; }
    }
}
