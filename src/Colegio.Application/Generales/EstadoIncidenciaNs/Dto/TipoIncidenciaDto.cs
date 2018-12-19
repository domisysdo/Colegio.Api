using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Colegio.Models.Generales.EstadoIncidenciaNs;

namespace Colegio.Generales.EstadoIdenciaNs
{
    [AutoMap(typeof(EstadoIncidencia))]
    public class EstadoIncidenciaDto: EntityDto<int>
    {
        public string Descripcion { get; set; }
    }
}