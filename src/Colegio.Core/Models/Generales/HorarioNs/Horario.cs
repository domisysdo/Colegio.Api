using Abp.Domain.Entities.Auditing;
using Colegio.Enums;
using Colegio.Models.Generales.AulaNs;
using Colegio.Models.Inscripcion.GeneralNs.GrupoNs;
using System;

namespace Colegio.Models.Generales.HorarioNs
{
    public class Horario :  FullAuditedEntity<int>
    {
        public DiaSemanaEnum Dia { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFin { get; set; }
        public int GrupoId { get; set; }
        public virtual  Grupo Grupo { get; set; }
        public int AulaId { get; set; }
        public virtual Aula Aula { get; set; }
        
    }
}
