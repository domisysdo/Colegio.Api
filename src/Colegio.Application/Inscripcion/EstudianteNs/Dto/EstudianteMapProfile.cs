using AutoMapper;
using Colegio.Generales.EmailEstudianteNs;
using Colegio.Models.Generales.EmailEstudianteNs;
using Colegio.Models.Inscripcion.EstudianteNs;
using System.Collections.Generic;

namespace Colegio.Inscripcion.EstudianteNs.Dto
{
    public class EstudianteMapProfile: Profile
    {
        public EstudianteMapProfile()
        {
            CreateMap<EstudianteDto, Estudiante>();
            CreateMap<Estudiante, EstudianteDto>();

            //CreateMap<EmailEstudianteDto, EmailEstudiante>();
            //CreateMap<EmailEstudiante, EmailEstudianteDto>()
            //    .ForMember(x => x.TipoEmailNombre, o => o.MapFrom(x => x.TipoEmail.Descripcion));
        }
    }
}
