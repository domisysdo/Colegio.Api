using AutoMapper;
using Colegio.Models.Inscripcion.GeneralNs.PadecimientoNs;

namespace Colegio.Incripcion.PadecimientoNs.Dto
{
    public class PadecimientoMapProfile: Profile
    {
        public PadecimientoMapProfile()
        {
            CreateMap<PadecimientoDto, Padecimiento>();
            CreateMap<Padecimiento, PadecimientoDto>();
        }
    }
}
