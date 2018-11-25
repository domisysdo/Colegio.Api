using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Colegio.Models.Generales.EmailFamiliarEstudianteNs;

namespace Colegio.Generales.EmailFamiliarEstudianteNs
{
    [AutoMap(typeof(EmailFamiliarEstudiante))]
    public class EmailFamiliarEstudianteDto: EntityDto<int>
    {
        public string Email { get; set; }
        public int FamiliarEstudianteId { get; set; }
        public int TipoEmailId { get; set; }
    }
}