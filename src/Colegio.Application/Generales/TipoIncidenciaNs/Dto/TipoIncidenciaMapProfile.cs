using AutoMapper;
using Colegio.Generales.TipoIncidenciaNs;
using Colegio.Models.Generales.TipoIncidenciaNs;

namespace Colegio.Generales.PaisNs.Dto
{
    public class TipoIncidenciaMapProfile: Profile
    {
        public TipoIncidenciaMapProfile()
        {
            CreateMap<TipoIncidenciaDto, TipoIncidencia>();
            CreateMap<TipoIncidencia, TipoIncidenciaDto>();
        }
    }
}
