using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Colegio.Models.Generales.TipoIncidenciaNs;

namespace Colegio.Generales.TipoIncidenciaNs
{
    [AutoMap(typeof(TipoIncidencia))]
    public class TipoIncidenciaDto: EntityDto<int>
    {
        public string Descripcion { get; set; }
    }
}