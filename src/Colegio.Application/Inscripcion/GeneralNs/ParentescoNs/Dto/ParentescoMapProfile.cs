using AutoMapper;
using Colegio.Models.Inscripcion.GeneralNs.ParentescoNs;

namespace Colegio.Incripcion.ParentescoNs.Dto
{
    public class ParentescoMapProfile: Profile
    {
        public ParentescoMapProfile()
        {
            CreateMap<ParentescoDto, Parentesco>();
            CreateMap<Parentesco, ParentescoDto>();
        }
    }
}
