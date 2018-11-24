using Abp.Domain.Entities.Auditing;
using Colegio.Models.Generales.DireccionFamiliarEstudianteNs;
using Colegio.Models.Generales.EmailFamiliarEstudianteNs;
using Colegio.Models.Generales.LugarTrabajoNs;
using Colegio.Models.Generales.ProfesionNs;
using Colegio.Models.Generales.TelefonoFamiliarNs;
using Colegio.Models.Generales.TipoIdentificacionNs;
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
        public int LugarTrabajoId { get; set; }
        public LugarTrabajo LugarTrabajo { get; set; }
        public int ProfesionId { get; set; }
        public virtual Profesion Profesion { get; set; }
        public int TipoIdentificacionId { get; set; }
        public virtual TipoIdentificacion TipoIdentificacion { get; set; }
        public virtual IEnumerable<TelefonoFamiliarEstudiante> ListaTelefonos { get; set; }
        public virtual IEnumerable<EmailFamiliarEstudiante> ListaEmail { get; set; }
        public virtual IEnumerable<DireccionFamiliarEstudiante> ListaDireccion { get; set; }
    }
}
