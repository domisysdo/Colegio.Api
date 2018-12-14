using AutoMapper;
using Colegio.Models.Nomina.ProfesorMateriaNs;

namespace Colegio.Nomina.ProfesorMateriaNs
{
    public class ProfesorMateriaMapProfile: Profile
    {
        public ProfesorMateriaMapProfile()
        {
            CreateMap<ProfesorMateriaDto, ProfesorMateria>();
            CreateMap<ProfesorMateria, ProfesorMateriaDto>()
                .ForMember(x => x.MateriaNombre, o => o.MapFrom(x => x.Materia.Nombre))
                .ForMember(x => x.ProfesorNombre, o => o.MapFrom(x => x.Profesor.Nombres + " " + 
                                                                 x.Profesor.PrimerApellido + " " +
                                                                 x.Profesor.SegundoApellido));
        }
    }
}
