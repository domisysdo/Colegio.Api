using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Colegio.Models.Generales.MunicipioNs;

namespace Colegio.Generales.MunicipioNs
{
    [AutoMap(typeof(Municipio))]
    public class MunicipioDto: EntityDto<int>
    {
        public string Identificador { get; set; }
        public string Nombre { get; set; }
        public string IdentificadorNombre { get; set; }
        public string ProvinciaNombre { get; set; }
        public int ProvinciaId { get; set; }
    }
}