using AutoMapper;
using Colegio.Models.Notas.CalificacionNs;
using Colegio.Notas.CalificacionNs;

namespace Colegio.Generales.MetodoEvaluacionNs.Dto
{
    public class CalificacionMapProfile : Profile
    {
        public CalificacionMapProfile()
        {
            CreateMap<CalificacionDto, Calificacion>();
            CreateMap<Calificacion, CalificacionDto>()
                .ForMember(x => x.EstudianteNombreCompleto, 
                           o => o.MapFrom(x => x.Estudiante.Nombres + " " + x.Estudiante.PrimerApellido + " " +
                                                                            x.Estudiante.SegundoApellido))

                .ForMember(x => x.EstudianteIdentificador, 
                           o => o.MapFrom(x => x.Estudiante.Identificador))

                .ForMember(x => x.GrupoIdentificador, 
                           o => o.MapFrom(x => x.Grupo.Identificador))

                .ForMember(x => x.MateriaNombre, 
                           o => o.MapFrom(x => x.Materia.Identificador + " " + x.Materia.Nombre))

                .ForMember(x => x.DetalleMetodoEvaluacionDescripcion, 
                           o => o.MapFrom(x => x.DetalleMetodoEvaluacion.Descripcion));
        }
    }
}
