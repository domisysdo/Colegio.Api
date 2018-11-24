using AutoMapper;
using Colegio.Models.Generales.TipoEmailNs;

namespace Colegio.Generales.TipoEmailNs.Dto
{
    public class TipoEmailMapProfile: Profile
    {
        public TipoEmailMapProfile()
        {
            CreateMap<TipoEmailDto, TipoEmail>();
            CreateMap<TipoEmail, TipoEmailDto>();
        }
    }
}
