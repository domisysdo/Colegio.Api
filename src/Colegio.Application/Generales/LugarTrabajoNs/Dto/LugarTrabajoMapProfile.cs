using AutoMapper;
using Colegio.Generales.LugarTrabajoNs;
using Colegio.Models.Generales.LugarTrabajoNs;

namespace Colegio.Generales.PaisNs.Dto
{
    public class LugarTrabajoMapProfile: Profile
    {
        public LugarTrabajoMapProfile()
        {
            CreateMap<LugarTrabajoDto, LugarTrabajo>();
            CreateMap<LugarTrabajo, LugarTrabajoDto>();
        }
    }
}
