using AutoMapper;
using Colegio.Generales.IncidenciaEstudianteNs;
using Colegio.Models.Generales.IncidenciaEstudianteNs;

namespace Colegio.Generales.PaisNs.Dto
{
    public class IncidenciaEstudianteMapProfile: Profile
    {
        public IncidenciaEstudianteMapProfile()
        {
            CreateMap<IncidenciaEstudianteDto, IncidenciaEstudiante>();
            CreateMap<IncidenciaEstudiante, IncidenciaEstudianteDto>();
        }
    }
}
