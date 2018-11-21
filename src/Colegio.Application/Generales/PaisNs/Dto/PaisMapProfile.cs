using AutoMapper;
using Colegio.Models.Generales.PaisNs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Colegio.Generales.PaisNs.Dto
{
    public class PaisMapProfile: Profile
    {
        public PaisMapProfile()
        {
            CreateMap<PaisDto, Pais>();
            CreateMap<Pais, PaisDto>()
                .ForMember(x => x.IdentificadorNombre, o => o.MapFrom(x => x.Identificador + " - " + x.Nombre));
        }
    }
}
