using Abp.Domain.Entities.Auditing;
using Colegio.Models.Inscripcion.EstudianteNs;
using Colegio.Models.Inscripcion.GeneralNs.GrupoNs;
using Colegio.Models.Inscripcion.GeneralNs.MateriaNs;
using Colegio.Models.Notas.MetodoEvaluacionNs;

namespace Colegio.Models.Notas.CalificacionNs
{
    public class Calificacion: AuditedEntity<int>
    {
        public int EstudianteId { get; set; }
        public int GrupoId { get; set; }
        public int MateriaId { get; set; }
        public int DetalleMetodoEvaluacionId { get; set; }
        public int Puntuacion { get; set; }
        public virtual Estudiante Estudiante { get; set; }
        public virtual Grupo Grupo { get; set; }
        public virtual Materia Materia { get; set; }
        public virtual DetalleMetodoEvaluacion DetalleMetodoEvaluacion { get; set; }
    }
}
