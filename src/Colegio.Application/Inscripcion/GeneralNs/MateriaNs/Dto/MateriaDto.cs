﻿using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Colegio.Models.Inscripcion.GeneralNs.MateriaNs;

namespace Colegio.Inscripcion.MateriaNs
{
    [AutoMap(typeof(Materia))]
    public class MateriaDto: EntityDto<int>
    {
        public string Identificador { get; set; }
        public string Nombre { get; set; }
        public decimal PrecioTotal { get; set; }
        public decimal PrecioInscripcion { get; set; }
    }
}