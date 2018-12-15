using AutoMapper;
using Colegio.Models.Nomina.ProfesorGrupoNs;

namespace Colegio.Nomina.ProfesorMateriaNs
{
    public class ProfesorGrupoMapProfile : Profile
    {
        public ProfesorGrupoMapProfile()
        {
            CreateMap<ProfesorGrupoDto, ProfesorGrupo>();
            CreateMap<ProfesorGrupo, ProfesorGrupoDto>()
                .ForMember(x => x.ProfesorNombre, o => o.MapFrom(x => x.Profesor.Nombres + " " +
                                                                 x.Profesor.PrimerApellido + " " +
                                                                 x.Profesor.SegundoApellido));
        }
    }
}
