﻿using AutoMapper;
using Colegio.Generales.EmailEstudianteNs;
using Colegio.Models.Generales.EmailEstudianteNs;

namespace Colegio.Generales.PaisNs.Dto
{
    public class EmailEstudianteMapProfile : Profile
    {
        public EmailEstudianteMapProfile()
        {
            CreateMap<EmailEstudianteDto, EmailEstudiante>();               
            CreateMap<EmailEstudiante, EmailEstudianteDto>()
                .ForMember(x => x.TipoEmailNombre, o => o.MapFrom(x => x.TipoEmail.Descripcion));
        }
    }
}
