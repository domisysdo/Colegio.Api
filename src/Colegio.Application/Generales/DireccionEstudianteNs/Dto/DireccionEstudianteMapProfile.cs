using AutoMapper;
using Colegio.Generales.DireccionEstudianteNs;
using Colegio.Models.Generales.DireccionEstudianteNs;

namespace Colegio.Generales.PaisNs.Dto
{
    public class DireccionEstudianteMapProfile: Profile
    {
        public DireccionEstudianteMapProfile()
        {
            CreateMap<DireccionEstudianteDto, DireccionEstudiante>();
            CreateMap<DireccionEstudiante, DireccionEstudianteDto>();
        }
    }
}
