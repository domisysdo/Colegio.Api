using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Colegio.Incripcion.GrupoNs;
using Colegio.Models.Inscripcion.InscripcionNs;
using Colegio.Incripcion.EstudianteNs;
using Colegio.Incripcion.PeriodoNs;

namespace Colegio.Incripcion.InscripcionNs
{
    [AutoMap(typeof(Inscripcion))]
    public class InscripcionDto: EntityDto<int>
    {
        public int EstudianteId { get; set; }
        public virtual EstudianteDto Estudiante { get; set; }
        public int GrupoId { get; set; }
        public virtual GrupoDto Grupo { get; set; }
        public int PeriodoId { get; set; }
        public virtual PeriodoDto Periodo { get; set; }
    }
}