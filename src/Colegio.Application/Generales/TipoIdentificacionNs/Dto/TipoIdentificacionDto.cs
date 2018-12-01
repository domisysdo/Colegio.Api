using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Colegio.Models.Generales.TipoIdentificacionNs;

namespace Colegio.Generales.TipoIdentificacionNs
{
    [AutoMap(typeof(TipoIdentificacion))]
    public class TipoIdentificacionDto: EntityDto<int>
    {
        public string Descripcion { get; set; }
    }
}