using AutoMapper;
using Colegio.Nomina.ProfesorNs;
using Colegio.Models.Nomina.ProfesorNs;

namespace Colegio.Nomina.ProfesorNs.Dto
{
    public class ProfesorMapProfile: Profile
    {
        public ProfesorMapProfile()
        {
            CreateMap<ProfesorDto, Profesor>();
            CreateMap<Profesor, ProfesorDto>();
        }
    }
}
