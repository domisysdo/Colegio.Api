using AutoMapper;
using Colegio.Models.Inscripcion.GeneralNs.MateriaNs;

namespace Colegio.Inscripcion.MateriaNs.Dto
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
