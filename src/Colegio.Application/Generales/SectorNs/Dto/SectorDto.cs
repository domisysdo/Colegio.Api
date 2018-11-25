using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Colegio.Models.Generales.SectorNs;

namespace Colegio.Generales.SectorNs
{
    [AutoMap(typeof(Sector))]
    public class SectorDto: EntityDto<int>
    {
        public string Identificador { get; set; }
        public string Nombre { get; set; }
        public string IdentificadorNombre { get; set; }
        public string MunicipioNombre { get; set; }
        public int MunicipioId { get; set; }
    }
}