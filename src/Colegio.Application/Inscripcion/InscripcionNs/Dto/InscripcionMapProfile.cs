using AutoMapper;
using Colegio.Models.Inscripcion.InscripcionNs;

namespace Colegio.Incripcion.InscripcionNs.Dto
{
    public class InscripcionMapProfile: Profile
    {
        public InscripcionMapProfile()
        {
            CreateMap<InscripcionDto, Inscripcion>();
            CreateMap<Inscripcion, InscripcionDto>();
        }
    }
}
