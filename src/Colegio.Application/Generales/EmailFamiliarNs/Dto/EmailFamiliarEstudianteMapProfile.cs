using AutoMapper;
using Colegio.Generales.EmailFamiliarEstudianteNs;
using Colegio.Models.Generales.EmailFamiliarEstudianteNs;

namespace Colegio.Generales.PaisNs.Dto
{
    public class EmailFamiliarEstudianteMapProfile: Profile
    {
        public EmailFamiliarEstudianteMapProfile()
        {
            CreateMap<EmailFamiliarEstudianteDto, EmailFamiliarEstudiante>();
            CreateMap<EmailFamiliarEstudiante, EmailFamiliarEstudianteDto>();
        }
    }
}
