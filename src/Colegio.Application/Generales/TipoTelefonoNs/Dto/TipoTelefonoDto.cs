using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Colegio.Models.Generales.TipoTelefonoNs;

namespace Colegio.Generales.TipoTelefonoNs
{
    [AutoMap(typeof(TipoTelefono))]
    public class TipoTelefonoDto: EntityDto<int>
    {
        public string Descripcion { get; set; }
    }
}