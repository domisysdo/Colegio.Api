using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Colegio.Models.Generales.NacionalidadNs;

namespace Colegio.Generales.NacionalidadNs
{
    [AutoMap(typeof(Nacionalidad))]
    public class NacionalidadDto: EntityDto<int>
    {
        public string Identificador { get; set; }
        public string Descripcion { get; set; }
    }
}