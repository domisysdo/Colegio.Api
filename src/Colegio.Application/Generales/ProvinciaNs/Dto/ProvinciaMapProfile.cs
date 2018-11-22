using AutoMapper;
using Colegio.Generales.ProvinciaNs;
using Colegio.Models.Generales.ProvinciaNs;

namespace Colegio.Generales.PaisNs.Dto
{
    public class ProvinciaMapProfile: Profile
    {
        public ProvinciaMapProfile()
        {
            CreateMap<ProvinciaDto, Provincia>();
            CreateMap<Provincia, ProvinciaDto>()
                .ForMember(x => x.IdentificadorNombre, o => o.MapFrom(x => x.Identificador + " - " + x.Nombre))
                .ForMember(x => x.PaisNombre, o => o.MapFrom(x => x.Pais.Nombre));
        }
    }
}
