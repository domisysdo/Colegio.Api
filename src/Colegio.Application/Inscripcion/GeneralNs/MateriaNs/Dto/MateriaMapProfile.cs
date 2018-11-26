using AutoMapper;
using Colegio.Models.Inscripcion.GeneralNs.MateriaNs;

namespace Colegio.Incripcion.MateriaNs.Dto
{
    public class MateriaMapProfile: Profile
    {
        public MateriaMapProfile()
        {
            CreateMap<MateriaDto, Materia>();
            CreateMap<Materia, MateriaDto>();
        }
    }
}
