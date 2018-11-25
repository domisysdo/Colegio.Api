using AutoMapper;
using Colegio.Generales.DireccionFamiliarEstudianteNs;
using Colegio.Models.Generales.DireccionFamiliarEstudianteNs;

namespace Colegio.Generales.PaisNs.Dto
{
    public class DireccionFamiliarEstudianteMapProfile: Profile
    {
        public DireccionFamiliarEstudianteMapProfile()
        {
            CreateMap<DireccionFamiliarEstudianteDto, DireccionFamiliarEstudiante>();
            CreateMap<DireccionFamiliarEstudiante, DireccionFamiliarEstudianteDto>();
        }
    }
}
