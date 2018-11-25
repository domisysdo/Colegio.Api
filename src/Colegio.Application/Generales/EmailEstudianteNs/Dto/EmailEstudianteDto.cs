using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Colegio.Models.Generales.EmailEstudianteNs;

namespace Colegio.Generales.EmailEstudianteNs
{
    [AutoMap(typeof(EmailEstudiante))]
    public class EmailEstudianteDto: EntityDto<int>
    {
        public string Email { get; set; }
        public int EstudianteId { get; set; }
        public int TipoEmailId { get; set; }
    }
}