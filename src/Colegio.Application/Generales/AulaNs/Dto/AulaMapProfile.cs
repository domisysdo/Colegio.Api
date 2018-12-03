using AutoMapper;
using Colegio.Models.Generales.AulaNs;

namespace Colegio.Generales.AulaNs.Dto
{
    public class AulaMapProfile : Profile
    {
        public AulaMapProfile()
        {
            CreateMap<AulaDto, Aula>();
            CreateMap<Aula, AulaDto>()
                .ForMember(x => x.Identificador, o => o.MapFrom(x => x.Identificador));
                
        }
    }
}
