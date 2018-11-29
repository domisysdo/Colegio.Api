using AutoMapper;
using Colegio.Generales.TipoPadecimientoNs;
using Colegio.Models.Generales.TipoPadecimientoNs;

namespace Colegio.Generales.TipoPadecimientoNs.Dto
{
    public class TipoPadecimientoMapProfile : Profile
    {
        public TipoPadecimientoMapProfile()
        {
            CreateMap<TipoPadecimientoDto , TipoPadecimiento>();
            CreateMap<TipoPadecimiento, TipoPadecimientoDto>();
        }
    }
}
