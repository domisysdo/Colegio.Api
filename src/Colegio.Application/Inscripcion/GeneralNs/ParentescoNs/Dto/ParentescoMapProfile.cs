using AutoMapper;
using Colegio.Models.Inscripcion.GeneralNs.ParentescoNs;

namespace Colegio.Inscripcion.ParentescoNs.Dto
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
