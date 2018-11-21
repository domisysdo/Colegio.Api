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
            CreateMap<PaisDto, Pais>().ReverseMap();
        }
    }
}
