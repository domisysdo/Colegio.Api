using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Colegio.Models.Generales.ProvinciaNs;

namespace Colegio.Generales.ProvinciaNs
{
    [AutoMap(typeof(Provincia))]
    public class ProvinciaDto: EntityDto<int>
    {
        public string Identificador { get; set; }
        public string Nombre { get; set; }
        public string IdentificadorNombre { get; set; }
        public string PaisNombre { get; set; }
        public int PaisId { get; set; }
    }
}