using AutoMapper;
using Colegio.Models.Inscripcion.InscripcionNs;

namespace Colegio.Inscripcion.InscripcionNs.Dto
{
    public class InscripcionMapProfile: Profile
    {
        public InscripcionMapProfile()
        {
            CreateMap<InscripcionDto, Models.Inscripcion.InscripcionNs.Inscripcion>();
            CreateMap<Models.Inscripcion.InscripcionNs.Inscripcion, InscripcionDto>();
        }
    }
}
