using AutoMapper;
using Colegio.Models.Inscripcion.CuotaNs;

namespace Colegio.Inscripcion.CuotaNs.Dto
{
    public class CuotaMapProfile: Profile
    {
        public CuotaMapProfile()
        {
            CreateMap<CuotaDto, Cuota>();
            CreateMap<Cuota, CuotaDto>()
            .ForMember(x => x.MontoMoraPendiente, o => o.MapFrom(x => x.MontoMora - x.MontoMoraPago));
        }
    }
}
