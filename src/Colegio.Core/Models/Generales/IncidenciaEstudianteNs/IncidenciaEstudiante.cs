using Abp.Domain.Entities.Auditing;
using Colegio.Models.Generales.TipoIncidenciaNs;
using Colegio.Models.Inscripcion.EstudianteNs;
using Colegio.Models.Inscripcion.GeneralNs.MateriaNs;
using System;

namespace Colegio.Models.Generales.IncidenciaEstudianteNs
{
    public class IncidenciaEstudiante : AuditedEntity<int>
    {   
        public bool Justificada { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }
        public int MateriaId { get; set; }
        public Materia Materia { get; set; }
        public int EstudianteId { get; set; }
        public virtual Estudiante Estudiante { get; set; }
        public int TipoIncidenciaId { get; set; }
        public virtual TipoIncidencia TipoIncidencia { get; set; }
    }
}
