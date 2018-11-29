using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Colegio.Models.Inscripcion.GeneralNs.CostoInscripcionNs;

namespace Colegio.Incripcion.CostoInscripcionNs
{
    [AutoMap(typeof(CostoInscripcion))]
    public class CostoInscripcionDto : EntityDto<int>
    {
        public int GrupoId { get; set; }
        public decimal Costoinscripcion { get; set; }
        public decimal Costomensualidad { get; set; }
    }
}