using AutoMapper;
using Colegio.Generales.EstadoIdenciaNs;
using Colegio.Models.Generales.EstadoIncidenciaNs;

namespace Colegio.Generales.PaisNs.Dto
{
    public class EstadoIncidenciaMapProfile: Profile
    {
        public EstadoIncidenciaMapProfile()
        {
            CreateMap<EstadoIncidenciaDto, EstadoIncidencia>();
            CreateMap<EstadoIncidencia, EstadoIncidenciaDto>();
        }
    }
}
