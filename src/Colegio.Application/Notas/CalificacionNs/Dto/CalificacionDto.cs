using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Colegio.Models.Notas.CalificacionNs;

namespace Colegio.Notas.CalificacionNs
{
    [AutoMap(typeof(Calificacion))]
    public class CalificacionDto: EntityDto<int>
    {
        public int EstudianteId { get; set; }
        public int GrupoId { get; set; }
        public int MateriaId { get; set; }
        public int DetalleMetodoEvaluacionId { get; set; }
        public int Puntuacion { get; set; }
        public string EstudianteNombreCompleto { get; set; }
        public string EstudianteIdentificador { get; set; }
        public string GrupoIdentificador { get; set; }
        public string MateriaNombre { get; set; }
        public string DetalleMetodoEvaluacionDescripcion { get; set; }
    }
}