using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Colegio.Models.Generales.LugarTrabajoNs;
using System;

namespace Colegio.Generales.LugarTrabajoNs
{
    [AutoMap(typeof(LugarTrabajo))]
    public class LugarTrabajoDto: EntityDto<int>
    {
        public string Descripcion { get; set; }
        public int SectorId { get; set; }
    }
}