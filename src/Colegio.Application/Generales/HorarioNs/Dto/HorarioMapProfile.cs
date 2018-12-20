using AutoMapper;
using Colegio.Models.Generales.HorarioNs;

namespace Colegio.Generales.HorarioNs.Dto
{
    public class HorarioMapProfile : Profile
    {
        public HorarioMapProfile()
        {
            CreateMap<HorarioDto, Horario>();
            CreateMap<Horario, HorarioDto>()
                .ForMember(x => x.AulaIdentificador, o => o.MapFrom(x => x.Aula.Identificador));
        }
    }
}
