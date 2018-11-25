using AutoMapper;
using Colegio.Generales.ProfesionNs;
using Colegio.Models.Generales.ProfesionNs;

namespace Colegio.Generales.PaisNs.Dto
{
    public class ProfesionMapProfile: Profile
    {
        public ProfesionMapProfile()
        {
            CreateMap<ProfesionDto, Profesion>();
            CreateMap<Profesion, ProfesionDto>();
        }
    }
}
