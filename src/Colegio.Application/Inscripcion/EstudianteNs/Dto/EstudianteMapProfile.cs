using AutoMapper;
using Colegio.Models.Inscripcion.EstudianteNs;

namespace Colegio.Incripcion.EstudianteNs.Dto
{
    public class EstudianteMapProfile: Profile
    {
        public EstudianteMapProfile()
        {
            CreateMap<EstudianteDto, Estudiante>();
            CreateMap<Estudiante, EstudianteDto>();
        }
    }
}
