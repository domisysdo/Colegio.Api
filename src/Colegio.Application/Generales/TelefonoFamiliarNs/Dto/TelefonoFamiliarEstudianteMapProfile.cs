using AutoMapper;
using Colegio.Generales.TelefonoFamiliarEstudianteNs;
using Colegio.Models.Generales.TelefonoFamiliarNs;

namespace Colegio.Generales.PaisNs.Dto
{
    public class TelefonoFamiliarEstudianteMapProfile: Profile
    {
        public TelefonoFamiliarEstudianteMapProfile()
        {
            CreateMap<TelefonoFamiliarEstudianteDto, TelefonoFamiliarEstudiante>();
            CreateMap<TelefonoFamiliarEstudiante, TelefonoFamiliarEstudianteDto>();
        }
    }
}
