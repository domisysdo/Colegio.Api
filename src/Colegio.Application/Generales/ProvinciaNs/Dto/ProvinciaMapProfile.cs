using AutoMapper;
using Colegio.Generales.ProvinciaNs;
using Colegio.Models.Generales.ProvinciaNs;

namespace Colegio.Generales.PaisNs.Dto
{
    public class ProvinciaMapProfile: Profile
    {
        public ProvinciaMapProfile()
        {
            CreateMap<ProvinciaDto, Provincia>().ReverseMap();
        }
    }
}
