using AutoMapper;
using Colegio.Generales.TipoTelefonoNs;
using Colegio.Models.Generales.TipoTelefonoNs;

namespace Colegio.Generales.PaisNs.Dto
{
    public class TipoTelefonoMapProfile: Profile
    {
        public TipoTelefonoMapProfile()
        {
            CreateMap<TipoTelefonoDto, TipoTelefono>();
            CreateMap<TipoTelefono, TipoTelefonoDto>();
        }
    }
}
