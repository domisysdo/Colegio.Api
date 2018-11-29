using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Colegio.Models.Generales.TipoPadecimientoNs;

namespace Colegio.Generales.TipoPadecimientoNs
{
    [AutoMap(typeof(TipoPadecimiento))]
    public class TipoPadecimientoDto: EntityDto<int>
    {
        public string Descripcion { get; set; }
    }
}