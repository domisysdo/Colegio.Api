using AutoMapper;
using Colegio.Generales.SectorNs;
using Colegio.Models.Generales.SectorNs;

namespace Colegio.Generales.PaisNs.Dto
{
    public class SectorMapProfile: Profile
    {
        public SectorMapProfile()
        {
            CreateMap<SectorDto, Sector>();
            CreateMap<Sector, SectorDto>()
                .ForMember(x => x.IdentificadorNombre, o => o.MapFrom(x => x.Identificador + " - " + x.Nombre))
                .ForMember(x => x.MunicipioNombre, o => o.MapFrom(x => x.Municipio.Nombre));
        }
    }
}
