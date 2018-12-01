using AutoMapper;
using Colegio.Generales.TipoIdentificacionNs;
using Colegio.Models.Generales.TipoIdentificacionNs;

namespace Colegio.Generales.PaisNs.Dto
{
    public class TipoIdentificacionMapProfile: Profile
    {
        public TipoIdentificacionMapProfile()
        {
            CreateMap<TipoIdentificacionDto, TipoIdentificacion>();
            CreateMap<TipoIdentificacion, TipoIdentificacionDto>();
        }
    }
}
