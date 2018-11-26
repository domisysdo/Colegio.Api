using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Colegio.Models.Inscripcion.GeneralNs.PadecimientoNs;

namespace Colegio.Incripcion.PadecimientoNs
{
    [AutoMap(typeof(Padecimiento))]
    public class PadecimientoDto: EntityDto<int>
    {
        public string Descripcion { get; set; }
        public string Nota { get; set; }
        public int EstudianteId { get; set; }
    }
}