using AutoMapper;
using Colegio.Generales.MunicipioNs;
using Colegio.Models.Generales.MunicipioNs;

namespace Colegio.Generales.PaisNs.Dto
{
    public class MunicipioMapProfile: Profile
    {
        public MunicipioMapProfile()
        {
            CreateMap<MunicipioDto, Municipio>();
            CreateMap<Municipio, MunicipioDto>()
                .ForMember(x => x.IdentificadorNombre, o => o.MapFrom(x => x.Identificador + " - " + x.Nombre))
                .ForMember(x => x.ProvinciaNombre, o => o.MapFrom(x => x.Provincia.Nombre));
        }
    }
}
