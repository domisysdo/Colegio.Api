using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Colegio.Generales.EstadoIdenciaNs;
using Colegio.Models.Generales.TipoIncidenciaNs;
using System.Collections.Generic;

namespace Colegio.Generales.TipoIncidenciaNs
{
    [AutoMap(typeof(TipoIncidencia))]
    public class TipoIncidenciaDto: EntityDto<int>
    {
        public string Descripcion { get; set; }
        public List<EstadoIncidenciaDto> ListaEstadoIncidencia { get; set; }
    }
}