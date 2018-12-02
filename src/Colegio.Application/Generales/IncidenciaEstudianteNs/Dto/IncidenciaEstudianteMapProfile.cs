using AutoMapper;
using Colegio.Generales.IncidenciaEstudianteNs;
using Colegio.Models.Generales.IncidenciaEstudianteNs;

namespace Colegio.Generales.PaisNs.Dto
{
    public class IncidenciaEstudianteMapProfile : Profile
    {
        public IncidenciaEstudianteMapProfile()
        {
            CreateMap<IncidenciaEstudianteDto, IncidenciaEstudiante>();
            CreateMap<IncidenciaEstudiante, IncidenciaEstudianteDto>()
                .ForMember(x => x.EstudianteNombreCompleto,
                           o => o.MapFrom(x => x.Estudiante.Nombres + " " +
                           x.Estudiante.PrimerApellido + " " + x.Estudiante.SegundoApellido))
                
                .ForMember(x => x.MateriaNombre, o => o.MapFrom(x => x.Materia.Nombre))

                .ForMember(x => x.TipoIncidenciaNombre, o => o.MapFrom(x => x.TipoIncidencia.Descripcion));
        }
    }
}
