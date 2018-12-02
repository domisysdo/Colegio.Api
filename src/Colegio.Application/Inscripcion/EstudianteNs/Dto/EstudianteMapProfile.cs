using AutoMapper;
using Colegio.Models.Inscripcion.EstudianteNs;

namespace Colegio.Inscripcion.EstudianteNs.Dto
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
