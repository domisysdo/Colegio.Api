using AutoMapper;
using Colegio.Models.Generales.NacionalidadNs;

namespace Colegio.Generales.NacionalidadNs.Dto
{
    public class NacionalidadMapProfile: Profile
    {
        public NacionalidadMapProfile()
        {
            CreateMap<NacionalidadDto, Nacionalidad>();
            CreateMap<Nacionalidad, NacionalidadDto>();
        }
    }
}
