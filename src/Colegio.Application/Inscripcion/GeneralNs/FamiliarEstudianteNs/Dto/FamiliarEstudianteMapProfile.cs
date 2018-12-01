using AutoMapper;
using Colegio.Models.Inscripcion.GeneralNs.FamiliarEstudianteNs;

namespace Colegio.Incripcion.FamiliarEstudianteNs.Dto
{
    public class FamiliarEstudianteMapProfile : Profile
    {
        public FamiliarEstudianteMapProfile()
        {
            CreateMap<FamiliarEstudianteDto, FamiliarEstudiante>();
            CreateMap<FamiliarEstudiante, FamiliarEstudianteDto>()
                .ForMember(x => x.ParentescoNombre, o => o.MapFrom(x => x.Parentesco.Descripcion))
                .ForMember(x => x.NombreCompleto, o => o.MapFrom(x => x.Nombres + " " + x.PrimerApellido + " " + x.SegundoApellido));
        }
    }
}
