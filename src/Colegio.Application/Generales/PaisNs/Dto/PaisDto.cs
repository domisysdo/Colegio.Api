using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Colegio.Models.Generales.PaisNs;

namespace Colegio.Generales.PaisNs
{
    [AutoMap(typeof(Pais))]
    public class PaisDto: EntityDto<int>
    {
        public string Identificador { get; set; }
        public string Nombre { get; set; }
        public string IdentificadorNombre { get; set; }
    }
}