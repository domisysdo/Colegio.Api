using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Colegio.Models.Generales.TelefonoEstudianteNs;

namespace Colegio.Generales.TelefonoEstudianteNs
{
    [AutoMap(typeof(TelefonoEstudiante))]
    public class TelefonoEstudianteDto: EntityDto<int>
    {
        public string Numero { get; set; }
        public int EstudianteId { get; set; }
        public int TipoTelefonoId { get; set; }
    }
}