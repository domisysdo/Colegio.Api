using AutoMapper;
using Colegio.Inscripcion.PagoNs;
using Colegio.Models.Inscripcion.PagoNs;

namespace Colegio.Inscripcion.PagoNs.Dto
{
    public class PagoMapProfile: Profile
    {
        public PagoMapProfile()
        {
            CreateMap<PagoDto, Pago>();
            CreateMap<Pago, PagoDto>();
        }
    }
}
