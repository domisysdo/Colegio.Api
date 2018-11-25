using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Colegio.Models.Generales.ProfesionNs;
using System;

namespace Colegio.Generales.ProfesionNs
{
    [AutoMap(typeof(Profesion))]
    public class ProfesionDto: EntityDto<int>
    {
        public string Descripcion { get; set; }
    }
}