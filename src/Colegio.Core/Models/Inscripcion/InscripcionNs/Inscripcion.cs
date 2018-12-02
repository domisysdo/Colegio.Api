using Abp.Domain.Entities.Auditing;
using Colegio.Enums;
using Colegio.Models.Inscripcion.EstudianteNs;
using Colegio.Models.Inscripcion.GeneralNs.GrupoNs;
using Colegio.Models.Inscripcion.GeneralNs.PeriodoNs;
using System;
using System.Collections.Generic;

namespace Colegio.Models.Inscripcion.InscripcionNs
{
    public class Inscripcion : FullAuditedEntity<int>
    {
        public int EstudianteId { get; set; }
        public virtual Estudiante Estudiante { get; set; }
        public int GrupoId { get; set; }
        public virtual Grupo Grupo { get; set; }
        public int PeriodoId { get; set; }
        public virtual Periodo Periodo { get; set; }
    }
}
