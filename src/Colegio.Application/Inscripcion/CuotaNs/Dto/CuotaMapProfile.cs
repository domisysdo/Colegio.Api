using AutoMapper;
using Colegio.Models.Inscripcion.CuotaNs;

namespace Colegio.Inscripcion.CuotaNs.Dto
{
    public class CuotaMapProfile: Profile
    {
        public CuotaMapProfile()
        {
            CreateMap<CuotaDto, Cuota>();
            CreateMap<Cuota, CuotaDto>();
        }
    }
}
