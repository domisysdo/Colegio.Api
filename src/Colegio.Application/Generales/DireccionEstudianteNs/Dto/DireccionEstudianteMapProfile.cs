using AutoMapper;
using Colegio.Generales.DireccionEstudianteNs;
using Colegio.Models.Generales.DireccionEstudianteNs;

namespace Colegio.Generales.DireccionEstudianteNs.Dto
{
    public class DireccionEstudianteMapProfile : Profile
    {
        public DireccionEstudianteMapProfile()
        {
            CreateMap<DireccionEstudianteDto, DireccionEstudiante>();
            CreateMap<DireccionEstudiante, DireccionEstudianteDto>()
                .ForMember(x => x.SectorNombre, o => o.MapFrom(x => x.Sector.Identificador + " " + x.Sector.Nombre))
                .ForMember(x => x.TipoDireccionNombre, o => o.MapFrom(x => x.TipoDireccion.Descripcion));

        }
    }
}
