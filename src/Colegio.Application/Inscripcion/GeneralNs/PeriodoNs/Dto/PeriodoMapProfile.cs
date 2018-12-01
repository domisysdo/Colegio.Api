using AutoMapper;
using Colegio.Models.Inscripcion.GeneralNs.PeriodoNs;

namespace Colegio.Incripcion.PeriodoNs.Dto
{
    public class PeriodoMapProfile: Profile
    {
        public PeriodoMapProfile()
        {
            CreateMap<PeriodoDto, Periodo>();
            CreateMap<Periodo, PeriodoDto>();
        }
    }
}
