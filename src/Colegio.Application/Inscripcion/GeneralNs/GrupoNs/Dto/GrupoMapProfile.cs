using AutoMapper;
using Colegio.Models.Inscripcion.GeneralNs.GrupoNs;

namespace Colegio.Incripcion.GrupoNs.Dto
{
    public class GrupoMapProfile: Profile
    {
        public GrupoMapProfile()
        {
            CreateMap<GrupoDto, Grupo>();
            CreateMap<Grupo, GrupoDto>();
        }
    }
}
