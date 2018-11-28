﻿using AutoMapper;
using Colegio.Generales.TelefonoEstudianteNs;
using Colegio.Models.Generales.TelefonoEstudianteNs;

namespace Colegio.Generales.PaisNs.Dto
{
    public class TelefonoEstudianteMapProfile : Profile
    {
        public TelefonoEstudianteMapProfile()
        {
            CreateMap<TelefonoEstudianteDto, TelefonoEstudiante>();
            CreateMap<TelefonoEstudiante, TelefonoEstudianteDto>()
                .ForMember(x => x.TipoTelefonoNombre, o => o.MapFrom(x => x.TipoTelefono.Descripcion));
        }
    }
}
