using Abp.Domain.Entities.Auditing;
using Colegio.Models.Generales.DireccionFamiliarEstudianteNs;
using Colegio.Models.Generales.EmailFamiliarEstudianteNs;
using Colegio.Models.Generales.ProfesionNs;
using Colegio.Models.Generales.TelefonoFamiliarNs;
using Colegio.Models.Generales.TipoIdentificacionNs;
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
        public virtual Profesion Profesion { get; set; }
        public int TipoIdentificacionId { get; set; }
        public virtual TipoIdentificacion TipoIdentificacion { get; set; }
        public virtual IEnumerable<TelefonoFamiliarEstudiante> ListaTelefonos { get; set; }
        public virtual IEnumerable<EmailFamiliarEstudiante> ListaEmails { get; set; }
        public virtual IEnumerable<DireccionFamiliarEstudiante> ListaDirecciones { get; set; }
    }
}
