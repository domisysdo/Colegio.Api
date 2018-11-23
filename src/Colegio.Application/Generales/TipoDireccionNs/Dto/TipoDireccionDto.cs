﻿using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Colegio.Models.Generales.TipoTelefonoNs;

namespace Colegio.Generales.TipoDireccionNs
{
    [AutoMap(typeof(TipoDireccion))]
    public class TipoDireccionDto: EntityDto<int>
    {
        public string Descripcion { get; set; }
    }
}