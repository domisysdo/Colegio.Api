using AutoMapper;
using Colegio.Inscripcion.PagoDetalleNs;
using Colegio.Models.Inscripcion.PagoDetalleNs;

namespace Colegio.Inscripcion.PagoDetalleNs.Dto
{
    public class PagoDetalleMapProfile: Profile
    {
        public PagoDetalleMapProfile()
        {
            CreateMap<PagoDetalleDto, PagoDetalle>();
            CreateMap<PagoDetalle, PagoDetalleDto>();
        }
    }
}
