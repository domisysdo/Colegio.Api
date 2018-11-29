using AutoMapper;
using Colegio.Models.Inscripcion.GeneralNs.CostoInscripcionNs;

namespace Colegio.Incripcion.CostoInscripcionNs.Dto
{
    public class CostoInscripcionMapProfile : Profile
    {
        public CostoInscripcionMapProfile()
        {
            CreateMap<CostoInscripcionDto, CostoInscripcion>();
            CreateMap<CostoInscripcion, CostoInscripcionDto>();
        }
    }
}
