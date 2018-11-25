using AutoMapper;
using Colegio.Generales.TipoDireccionNs;
using Colegio.Models.Generales.TipoDireccionNs;

namespace Colegio.Generales.PaisNs.Dto
{
    public class TipoDireccionMapProfile: Profile
    {
        public TipoDireccionMapProfile()
        {
            CreateMap<TipoDireccionDto, TipoDireccion>();
            CreateMap<TipoDireccion, TipoDireccionDto>();
        }
    }
}
