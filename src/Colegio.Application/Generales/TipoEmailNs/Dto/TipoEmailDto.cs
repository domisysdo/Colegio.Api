using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Colegio.Models.Generales.TipoEmailNs;

namespace Colegio.Generales.TipoEmailNs
{
    [AutoMap(typeof(TipoEmail))]
    public class TipoEmailDto: EntityDto<int>
    {
        public string Descripcion { get; set; }
    }
}