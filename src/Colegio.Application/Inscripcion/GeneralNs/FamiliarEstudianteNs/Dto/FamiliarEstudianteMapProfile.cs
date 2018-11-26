using AutoMapper;
using Colegio.Models.Inscripcion.GeneralNs.FamiliarEstudianteNs;

namespace Colegio.Incripcion.FamiliarEstudianteNs.Dto
{
    public class FamiliarEstudianteMapProfile: Profile
    {
        public FamiliarEstudianteMapProfile()
        {
            CreateMap<FamiliarEstudianteDto, FamiliarEstudiante>();
            CreateMap<FamiliarEstudiante, FamiliarEstudianteDto>();
        }
    }
}
